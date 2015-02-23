using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeAndLadders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            string[] Names = { Player0.Text.ToString(), Player1.Text.ToString(), Player2.Text.ToString(), Player3.Text.ToString() };
            GameWindow Window = new GameWindow((int)NoOfPlayers.Value, Names, this);
            Window.Show();
            this.Hide();
        }

        private void Player_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox PlayerName = (sender as TextBox);
            if (PlayerName.Text.Length >= 7  && PlayerName.Text.Substring(0, PlayerName.Text.Length - 1) == "Player")
            {
                PlayerName.Clear();
            }
            else
            {
                PlayerName.SelectAll();
            }
        }

        private void Player_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox PlayerName = (sender as TextBox);
            if (PlayerName.Text == "")
            {
                PlayerName.Text = PlayerName.Name;
            }
        }

        private void NoOfPlayers_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            (sender as Slider).Value = (int)(sender as Slider).Value;
        }
    }
}
