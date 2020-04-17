using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using Game.Engine; 
using Game.Engine.Skills;
using System.Linq;
using System.Collections.Generic;

namespace Game.Display
{
    /// <summary>
    /// Display the game world and animate the player character
    /// </summary>
    public partial class GamePage : Page
    {
        private MainWindow frameRef;
        private GameSession currentSession;
        protected double stepSize = 24.0;

        protected Dictionary<int, Image> monsterImages;
        protected string lastMove;
        public bool RemovableItems { get; set; } = false;
        public bool Movable { get; set; }
        public bool ItemSellFlag { get; set; } = false;
        public bool IgnoreNextKey { get; set; } = false;
        public GamePage(MainWindow frame)
        {
            InitializeComponent();
            frameRef = frame;
            frame.Background = new SolidColorBrush(Colors.Black);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += OnKeyDownHandler;
            // start game
            monsterImages = new Dictionary<int, Image>();
            currentSession = new GameSession(stepSize, this);
            Grid.SetColumn(Player, currentSession.PlayerPosLeft);
            Grid.SetRow(Player, currentSession.PlayerPosTop);
            // prepare animations
            Movable = true;
        }

        protected void OnKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // this function is called after a keyboard signal from the user
            // first, do everything that base Page class wants to do
            base.OnKeyDown(e);
            currentSession.CurrentKey = e.Key.ToString();
            if (!Movable) return; // sometimes we don't want the player to move (e.g. when battling or selling items)
            if(IgnoreNextKey) // see GameSession.LocationEvents for explanation
            {
                IgnoreNextKey = false;
                return;
            }
            // AvailableMoves[0..3] -> WSAD
            if ((e.Key == Key.Up || e.Key == Key.W) && currentSession.AvailableMoves[0])
            {
                MovePlayer("up");
            }

            if ((e.Key == Key.Down || e.Key == Key.S) && currentSession.AvailableMoves[1])
            {
                MovePlayer("down");
            }

            if ((e.Key == Key.Left || e.Key == Key.A) && currentSession.AvailableMoves[2])
            {
                MovePlayer("left");
            }

            if ((e.Key == Key.Right || e.Key == Key.D) && currentSession.AvailableMoves[3])
            {
                MovePlayer("right");
            }
        }
        public void MovePlayer(string direction)
        {
            // this function actually moves the player around
            Movable = false;
            switch(direction)
            {
                case "up":
                    lastMove = direction;
                    Grid.SetRow(Player, currentSession.PlayerPosTop - 1);
                    currentSession.PlayerPosTop -= 1;
                    break;
                case "down":
                    lastMove = direction;
                    Grid.SetRow(Player, currentSession.PlayerPosTop + 1);
                    currentSession.PlayerPosTop += 1;
                    break;
                case "left":
                    lastMove = direction;
                    Grid.SetColumn(Player, currentSession.PlayerPosLeft - 1);
                    currentSession.PlayerPosLeft -= 1;
                    break;
                case "right":
                    lastMove = direction;
                    Grid.SetColumn(Player, currentSession.PlayerPosLeft + 1);
                    currentSession.PlayerPosLeft += 1;
                    break;
                case "reverse":
                    switch (lastMove)
                    {
                        case "up":
                            Grid.SetRow(Player, currentSession.PlayerPosTop + 1);
                            currentSession.PlayerPosTop += 1;
                            break;
                        case "down":
                            Grid.SetRow(Player, currentSession.PlayerPosTop - 1);
                            currentSession.PlayerPosTop -= 1;
                            break;
                        case "left":
                            Grid.SetColumn(Player, currentSession.PlayerPosLeft + 1);
                            currentSession.PlayerPosLeft += 1;
                            break;
                        case "right":
                            Grid.SetColumn(Player, currentSession.PlayerPosLeft - 1);
                            currentSession.PlayerPosLeft -= 1;
                            break;
                    }
                    break;
                default:
                    return; // something went wrong, dont do anything
            }
            Movable = true;
        }
        public void AddConsoleText(string text)
        {
            // add more text to the console
            Console.AppendText(text+"\n");
            Console.ScrollToEnd();
        }
        public void AddConsoleText(int text)
        {
            // add more text to the console
            Console.AppendText(text.ToString() + "\n");
            Console.ScrollToEnd();
        }
        public void ListBoxSelected(Skill skill)
        {
            // receive a listbox item selected and inform the game session
            currentSession.CurrentSelection = skill;
        }

        // overriden methods to move items around the item grid

        protected FrameworkElement draggedImage;
        protected Point gridPosition, mousePosition;
        int prevX, prevY;
        protected void ItemsMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // mouse button was clicked
            var image = e.Source as Image;
            if ((Movable || ItemSellFlag) && image != null && ItemGrid.CaptureMouse())
            {
                mousePosition = e.GetPosition(ItemCanvas);
                prevX = MyGridPositionX(mousePosition);
                prevY = MyGridPositionY(mousePosition);
                draggedImage = image;
                ItemGrid.Children.Remove(draggedImage);
                draggedImage.Height = ItemGrid.ActualHeight / 6.0; // convenience rescaling (6 rows in the grid)
                draggedImage.Width = ItemGrid.ActualWidth / 5.0;
                ItemCanvas.Children.Add(draggedImage);
                Canvas.SetLeft(draggedImage,MyCanvasPositionX(mousePosition));
                Canvas.SetTop(draggedImage,MyCanvasPositionY(mousePosition));
            }
        }
        protected void ItemsMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // mouse button was released
            if (draggedImage != null)
            {
                ItemGrid.ReleaseMouseCapture();
                ItemCanvas.Children.Remove(draggedImage);
                if(RemovableItems)
                {
                    int gridPosX = (int)(5.0 * mousePosition.X / ItemCanvas.ActualWidth);
                    int gridPosY = (int)(6.0 * mousePosition.Y / ItemCanvas.ActualHeight);
                    if (gridPosX < 0 || gridPosX > 4 || gridPosY < 0 || gridPosY > 5)
                    {
                        currentSession.RemoveItemPosition(prevX, prevY);
                        // sell an item (it's just those two lines of game logic so I put them here)
                        currentSession.currentPlayer.Gold += Index.ProduceSpecificItem(draggedImage.Name).GoldValue;
                        currentSession.RefreshStats();
                        draggedImage = null;
                    }
                    else
                    {
                        ItemGrid.Children.Add(draggedImage);
                        Grid.SetRow(draggedImage, prevY);
                        Grid.SetColumn(draggedImage, prevX);
                        draggedImage = null;
                    }
                }
                else
                {
                    ItemGrid.Children.Add(draggedImage);
                    Grid.SetRow(draggedImage, MyGridPositionY(mousePosition));
                    Grid.SetColumn(draggedImage, MyGridPositionX(mousePosition));
                    // if the target already had an image, swap the selected two
                    Image oldImage = GetImageFromGrid(MyGridPositionX(mousePosition), MyGridPositionY(mousePosition), true);
                    if (oldImage != null)
                    {
                        Grid.SetRow(oldImage, prevY);
                        Grid.SetColumn(oldImage, prevX);
                    }
                    //
                    draggedImage = null;
                    currentSession.RemoveItemPosition(prevX, prevY);
                    currentSession.AddItemPosition(MyGridPositionX(mousePosition), MyGridPositionY(mousePosition));
                }
            }
        }
        protected void ItemsMouseMove(object sender, MouseEventArgs e)
        {
            // mouse button is held down and the cursor is being moved
            if (draggedImage != null)
            {
                var position = e.GetPosition(ItemCanvas);
                var offset =  position - mousePosition;
                mousePosition = position;
                Canvas.SetLeft(draggedImage, Canvas.GetLeft(draggedImage) + offset.X);
                Canvas.SetTop(draggedImage, Canvas.GetTop(draggedImage) + offset.Y);
            }
        }

        // utility function - get either the last or the second last image from a grid cell
        public Image GetImageFromGrid(int x, int y, bool secondToLast = false)
        {
            Image img = new Image();
            if(secondToLast)
            {
                try
                {
                   UIElement el = ItemGrid.Children.Cast<UIElement>().Where(f => Grid.GetColumn(f) == x && Grid.GetRow(f) == y).Reverse().Skip(1).First();
                   if ((el as Image) != null) img = (el as Image);
                }
                catch(Exception e)
                {
                    AddConsoleText(e.Message);
                }
            }
            else
            {
                try
                {
                    UIElement el = ItemGrid.Children.Cast<UIElement>().Where(f => Grid.GetColumn(f) == x && Grid.GetRow(f) == y).Reverse().First();
                    if ((el as Image) != null) img = (el as Image);
                }
                catch (Exception e)
                {
                    AddConsoleText(e.Message);
                }
            }
            return img;
        }

        // methods to convert between item grid and item canvas positions
        // this will help with smooth rendering
        protected int MyGridPositionX(Point position)
        {
            int gridPos = (int)(5.0 * position.X / ItemCanvas.ActualWidth);
            if (gridPos < 0) gridPos = 0;
            if (gridPos > 4) gridPos = 4;
            return gridPos;
        }
        protected int MyGridPositionY(Point position)
        {
            int gridPos = (int)(6.0 * position.Y / ItemCanvas.ActualHeight);
            if (gridPos < 0) gridPos = 0;
            if (gridPos > 5) gridPos = 5;
            return gridPos;
        }
        protected double MyCanvasPositionX(Point position)
        {
            double gridColumnWidth = ItemCanvas.ActualWidth / 5.0;
            double newPos = 0.0;
            while (newPos < position.X)
                newPos += gridColumnWidth;
            return newPos - gridColumnWidth;
        }
        protected double MyCanvasPositionY(Point position)
        {
            double rowColumnWidth = ItemCanvas.ActualHeight / 6.0;
            double newPos = 0.0;
            while (newPos < position.Y)
                newPos += rowColumnWidth;
            return newPos - rowColumnWidth;
        }

        // display world monsters
        public void AddMonster(int key, Image monster, int modulo)
        {
            if (monster != null)
            {
                monsterImages.Add(key, monster);
                WorldGrid.Children.Add(monsterImages[key]);
                Grid.SetRow(monsterImages[key], key / modulo);
                Grid.SetColumn(monsterImages[key], key % modulo);
            }
        }
        public void UpdateMonster(int key, Image monster, int modulo)
        {
            WorldGrid.Children.Remove(monsterImages[key]);
            if (monster != null)
            {
                monsterImages[key] = monster;
                WorldGrid.Children.Add(monsterImages[key]);
                Grid.SetRow(monsterImages[key], key / modulo);
                Grid.SetColumn(monsterImages[key], key % modulo);
            }
        }

    }
}
