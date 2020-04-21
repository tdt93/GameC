using System;
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
        private void LoadGame(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".bin"; // Default file extension
            dlg.Filter = "Text documents (.bin)|*.bin"; // Filter files by extension
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                GamePage gamePage = new GamePage(frameRef); // create a new GamePage
                frameRef.ParentFrame.Navigate(gamePage); // switch priority from MenuPage to GamePage
                gamePage.LoadGame(dlg.FileName);
            }
        }
        private void ExitGame(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown(); //close the application
        }
    }
}
