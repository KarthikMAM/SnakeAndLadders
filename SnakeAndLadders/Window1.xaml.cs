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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeAndLadders
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DispatcherTimer RollDice = new DispatcherTimer(DispatcherPriority.Render);
        Random valueGenerator = new Random();
        int finalValue;
        
        Ellipse[] diceDots;
        bool[,] dice;

        int counter;

        GameWindow gameWindow;

        public Window1(object sender)
        {
            InitializeComponent();
            gameWindow = sender as GameWindow;

            SetupDice();

            RollDice.Interval = TimeSpan.FromMilliseconds(300);
            RollDice.Tick += RollDice_Tick;
        }

        public void Start(int diceValue)
        {
            finalValue = diceValue;
            counter = 0;

            RollDice.Start();
        }

        void RollDice_Tick(object sender, EventArgs e)
        {
            if(counter < 6)
            {
                DisplayDice(valueGenerator.Next() % 6 + 1);
            }
            else if(counter == 6)
            {
                DisplayDice(finalValue);
            }
            else if(counter == 7)
            {
                RollDice.Stop();
                gameWindow.Show();
                this.Hide();
            }
            
            counter++;
        }

        
        void SetupDice()
        {
            diceDots = new Ellipse[7];
            dice = new bool[6, 7];

            diceDots[0] = Dice00;
            diceDots[1] = Dice01;
            diceDots[2] = Dice02;
            diceDots[3] = Dice03;
            diceDots[4] = Dice04;
            diceDots[5] = Dice05;
            diceDots[6] = Dice06;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    dice[i, j] = false;
                }
            }

            dice[0, 0] = true;

            dice[1, 2] = true;
            dice[1, 5] = true;

            dice[2, 0] = true;
            dice[2, 2] = true;
            dice[2, 5] = true;

            dice[3, 1] = true;
            dice[3, 3] = true;
            dice[3, 4] = true;
            dice[3, 6] = true;

            dice[4, 0] = true;
            dice[4, 1] = true;
            dice[4, 3] = true;
            dice[4, 4] = true;
            dice[4, 6] = true;

            dice[5, 1] = true;
            dice[5, 2] = true;
            dice[5, 3] = true;
            dice[5, 4] = true;
            dice[5, 5] = true;
            dice[5, 6] = true;
            dice[5, 6] = true;
        }

        void DisplayDice(int diceValue)
        {
            diceValue--;
            for (int i = 0; i < 7; i++)
            {
                if (dice[diceValue, i] == true)
                {
                    diceDots[i].Opacity = 1;
                }
                else
                {
                    diceDots[i].Opacity = 0;
                }
            }
        }

    }
}
