using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Game.Engine;
using Game.Engine.Skills;
using Game.Engine.Monsters;
using Game.Engine.CharacterClasses;

namespace Game.Display
{
    // prepare and display graphical elements during battles
    class BattleScene
    {
        protected Grid BattleGrid;
        protected RichTextBox battleConsole;
        protected ListBox moves;
        protected GamePage parentPage;
        protected Image playerImage;
        protected Image monsterImage;
        protected Player player;
        protected Monster monster;
        RichTextBox rtb1, rtb2, rtb3, rtb4, rtb5, rtb6, rtb7, rtb8, rtb9, rtb10, rtb11, rtb12;
        public Image ImgSetup { get; set; }
        public BattleScene(GamePage page, Player player, Monster monster)
        {
            parentPage = page;
            this.player = player;
            this.monster = monster;
            this.playerImage = player.GetImage();
            this.monsterImage = monster.GetImage();
        }

        public void SetupDisplay()
        {
            // initialize display elements
            BattleGrid = new Grid();
            for (int i = 0; i < 5; i++) BattleGrid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < 2; i++) BattleGrid.ColumnDefinitions.Add(new ColumnDefinition());
            // construct battle image
            Grid ImageGrid = new Grid();
            ImageGrid.Background = Brushes.Black;
            for (int i = 0; i < 12; i++) ImageGrid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < 2; i++) ImageGrid.ColumnDefinitions.Add(new ColumnDefinition());
            ImgSetup.Stretch = Stretch.Fill;
            ImageGrid.Children.Add(ImgSetup);
            Grid.SetColumn(ImgSetup, 0);
            Grid.SetColumnSpan(ImgSetup, 2);
            Grid.SetRow(ImgSetup, 0);
            Grid.SetRowSpan(ImgSetup, 8);
            playerImage.Stretch = Stretch.Uniform;
            monsterImage.Stretch = Stretch.Uniform;
            ImageGrid.Children.Add(playerImage);
            ImageGrid.Children.Add(monsterImage);
            Grid.SetColumn(playerImage, 0);
            Grid.SetColumn(monsterImage, 1);
            Grid.SetRow(playerImage, 1);
            Grid.SetRowSpan(playerImage, 3);
            Grid.SetRow(monsterImage, 1);
            Grid.SetRowSpan(monsterImage, 3);
            // still constructing battle image - statistics
            rtb1 = new RichTextBox();
            rtb2 = new RichTextBox();
            rtb3 = new RichTextBox();
            rtb4 = new RichTextBox();
            rtb5 = new RichTextBox();
            rtb6 = new RichTextBox();
            rtb7 = new RichTextBox();
            rtb8 = new RichTextBox();
            rtb9 = new RichTextBox();
            rtb10 = new RichTextBox();
            rtb11 = new RichTextBox();
            rtb12 = new RichTextBox();
            List<RichTextBox> rtbs = new List<RichTextBox>();
            rtbs.Add(rtb1);
            rtbs.Add(rtb2);
            rtbs.Add(rtb3);
            rtbs.Add(rtb4);
            rtbs.Add(rtb5);
            rtbs.Add(rtb6);
            rtbs.Add(rtb7);
            rtbs.Add(rtb8);
            rtbs.Add(rtb9);
            rtbs.Add(rtb10);
            rtbs.Add(rtb11);
            rtbs.Add(rtb12);
            foreach(RichTextBox rtb in rtbs)
            {
                rtb.Focusable = false;
                rtb.Background = Brushes.Black;
                rtb.Foreground = Brushes.Yellow;
                rtb.FontWeight = FontWeights.Bold;
                rtb.BorderThickness = new Thickness(0);
                ImageGrid.Children.Add(rtb);
            }
            Grid.SetColumn(rtb1, 0);
            Grid.SetColumn(rtb2, 0);
            Grid.SetColumn(rtb3, 0);
            Grid.SetColumn(rtb4, 0);
            Grid.SetColumn(rtb5, 0);
            Grid.SetColumn(rtb6, 0);
            Grid.SetColumn(rtb7, 1);
            Grid.SetColumn(rtb8, 1);
            Grid.SetColumn(rtb9, 1);
            Grid.SetColumn(rtb10, 1);
            Grid.SetColumn(rtb11, 1);
            Grid.SetColumn(rtb12, 1);
            Grid.SetRow(rtb1, 5);
            Grid.SetRow(rtb2, 6);
            Grid.SetRow(rtb3, 7);
            Grid.SetRow(rtb4, 8);
            Grid.SetRow(rtb5, 9);
            Grid.SetRow(rtb6, 10);
            Grid.SetRow(rtb7, 5);
            Grid.SetRow(rtb8, 6);
            Grid.SetRow(rtb9, 7);
            Grid.SetRow(rtb10, 8);
            Grid.SetRow(rtb11, 9);
            Grid.SetRow(rtb12, 10);
            RefreshStats();
            // add battle image to grid
            BattleGrid.Children.Add(ImageGrid);
            Grid.SetColumn(ImageGrid, 0);
            Grid.SetRow(ImageGrid, 0);
            Grid.SetRowSpan(ImageGrid, 2);
            // style
            moves = new ListBox();
            moves.Background = Brushes.Black;
            moves.Foreground = Brushes.White;
            moves.FontWeight = FontWeights.Bold;
            moves.FontSize = 12.0;
            moves.BorderThickness = new Thickness(1);
            moves.ItemContainerStyle = Application.Current.Resources["ListBoxRowHeight"] as Style;
            moves.SelectionChanged += new SelectionChangedEventHandler(SkillChosen);
            BattleGrid.Children.Add(moves);
            //positioning
            Grid.SetColumn(moves, 0);
            Grid.SetColumnSpan(moves, 2);
            Grid.SetRow(moves, 2);
            Grid.SetRowSpan(moves, 3);
            // battle text console
            battleConsole = new RichTextBox();
            battleConsole.Background = Brushes.Black;
            battleConsole.Foreground = Brushes.Yellow;
            battleConsole.FontWeight = FontWeights.Bold;
            battleConsole.SetValue(Paragraph.LineHeightProperty, 1.0);
            battleConsole.FontSize = 12.0;
            battleConsole.IsReadOnly = true;
            BattleGrid.Children.Add(battleConsole);
            Grid.SetColumn(battleConsole, 1);
            Grid.SetRow(battleConsole, 0);
            Grid.SetRowSpan(battleConsole, 2);
            // final
            parentPage.PageGrid.Children.Add(BattleGrid);
            Grid.SetColumn(BattleGrid, 0);
            Grid.SetRow(BattleGrid, 0);
            Grid.SetRowSpan(BattleGrid, 2);
        }
        public void EndDisplay()
        {
            // clean up
            if (BattleGrid != null) parentPage.PageGrid.Children.Remove(BattleGrid);
        }     
        public void SetSkills(List<Skill> skills)
        {
            // set skills for the player to choose from
            moves.ItemsSource = skills;
        }
        private void SkillChosen(object sender, RoutedEventArgs e)
        {
            // a skill has been chosen - inform the parent page which will do rest of the job
            var item = (ListBox)sender;
            parentPage.ListBoxSelected((Skill)item.SelectedItem);
        }
        public void ResetChoice()
        {
            // reset skill choice
            moves.SelectedItem = null;
        }
        public void SendBattleText(string text)
        {
            // send a text message to the battle console (not to the main game console)
            battleConsole.AppendText(text + "\n");
            battleConsole.ScrollToEnd();
        }
        public void SendColorText(string text, string color)
        {
            // same as SendBattleText, but in color
            if (battleConsole == null) return;
            SendBattleText(text);
            SolidColorBrush brush;
            switch (color)
            {
                case "yellow":
                    brush = Brushes.Yellow;
                    break;
                case "red":
                    brush = Brushes.Red;
                    break;
                case "green":
                    brush = Brushes.LimeGreen;
                    break;
                case "blue":
                    brush = Brushes.DodgerBlue;
                    break;
                default:
                    brush = Brushes.Yellow;
                    break;
            }
            foreach (var paragraph in battleConsole.Document.Blocks)
            {
                var text2 = new TextRange(paragraph.ContentStart, paragraph.ContentEnd).Text;
                if (text2 == text) paragraph.Foreground = brush;
            }
        }

        public void RefreshStats()
        {
            // refresh all statistics displayed
            rtb1.Document.Blocks.Clear();
            rtb1.AppendText("Health: " + player.Health);
            rtb2.Document.Blocks.Clear();
            rtb2.AppendText("Strength: " + player.Strength);
            rtb3.Document.Blocks.Clear();
            rtb3.AppendText("Armor: " + player.Armor);
            rtb4.Document.Blocks.Clear();
            rtb4.AppendText("Precision: " + player.Precision);
            rtb5.Document.Blocks.Clear();
            rtb5.AppendText("Magic Power: " + player.MagicPower);
            rtb6.Document.Blocks.Clear();
            rtb6.AppendText("Stamina: " + player.Stamina);
            rtb7.Document.Blocks.Clear();
            rtb7.AppendText("Health: " + monster.Health);
            rtb8.Document.Blocks.Clear();
            rtb8.AppendText("Strength: " + monster.Strength);
            rtb9.Document.Blocks.Clear();
            rtb9.AppendText("Armor: " + monster.Armor);
            rtb10.Document.Blocks.Clear();
            rtb10.AppendText("Precision: " + monster.Precision);
            rtb11.Document.Blocks.Clear();
            rtb11.AppendText("Magic Power: " + monster.MagicPower);
            rtb12.Document.Blocks.Clear();
            rtb12.AppendText("Stamina: " + monster.Stamina);
            AdjustStatDisplay();
        }
        private void AdjustStatDisplay()
        {
            // adjustments (don't ask me why this can't be done only once in xaml... )
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb1);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb2);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb3);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb4);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb5);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb6);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb7);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb8);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb9);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb10);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb11);
            System.Windows.Documents.EditingCommands.AlignCenter.Execute(null, rtb12);
        }
    }
}
