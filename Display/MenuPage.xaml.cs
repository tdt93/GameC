using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Game.Display
{
    /// <summary>
    /// Interactions for game menu and its buttons: Start Game, Load Game, Exit Game
    /// </summary>
    public partial class MenuPage : Page
    {
        private MainWindow frameRef;
        public MenuPage(MainWindow frame)
        {
            InitializeComponent();
            frameRef = frame;
            frame.Background = new SolidColorBrush(Colors.Beige);
        }
        private void StartGame(object sender, RoutedEventArgs e)
        {
            GamePage gamePage = new GamePage(frameRef); // create a new GamePage
            frameRef.ParentFrame.Navigate(gamePage); // switch priority from MenuPage to GamePage
        }
        private void ExitGame(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown(); //close the application
        }
    }
}
