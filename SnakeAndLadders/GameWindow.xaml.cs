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

namespace SnakeAndLadders
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    
    public struct PlayerDetails
    {
        public static int NoOfPlayers = 0, PlayerTracker = 0, RankTracker = 0;

        public int Score;
        public Label Rank;
        public Label Name;
        public Ellipse PieceColor, BoardPiece;

        public void AssignValues(string PlayerID, Label PlayerName, Ellipse PlayerColor, Ellipse PlayerPiece, Label PlayerRank, bool isPlaying)
        {
            Name = PlayerName;
            Name.Content = PlayerID;
            PieceColor = PlayerColor;
            BoardPiece = PlayerPiece;
            Rank = PlayerRank;

            Reset(isPlaying);
        }

        public void Reset(bool isPlaying)
        {
            if(isPlaying)
            {
                PieceColor.Opacity = 0.2;
                Name.Opacity = 0.2;
            }
            else
            {
                PieceColor.Opacity = 0;
                Name.Opacity = 0;
            }

            PlayerTracker = 0;
            RankTracker = 0;

            Score = -1;


            Grid.SetColumn(BoardPiece, 1);
            Grid.SetRow(BoardPiece, 10);

            Rank.Opacity = 0;
            Rank.Content = NoOfPlayers;

            BoardPiece.Opacity = 0;
        }
    }

    public partial class GameWindow : Window
    {
        int[,] boardPointToScore = new int[10, 10];
        int[] boardScoreToPoint = new int[101];
        
        Random getDiceValue = new Random();
        Window1 diceAnimationWindow;
        MainWindow Home;

        Ellipse[] diceDots;
        bool[,] dice;

        PlayerDetails[] Player = new PlayerDetails[4];

        public GameWindow(int count, string[] players, MainWindow home)
        {
            InitializeComponent();

            Home = home;
            diceAnimationWindow = new Window1(this);

            SetupPlayers(count, players);
            SetupDice();
            SetupBoard();
        }

        public void Reset()
        {
            for (int i = 0; i < PlayerDetails.NoOfPlayers; i++)
            {
                Player[i].Reset(true);
            }
            SetupDice();
            SetupBoard();
            Player[0].Name.Opacity = 1;
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

        void SetupPlayers(int playersCount, string[] playersName)
        {
            bool[] isPlaying = { false, false, false, false };
            for (int i = 0; i < playersCount; i++ )
            {
                isPlaying[i] = true;
            }
           
            PlayerDetails.NoOfPlayers = playersCount;
            Player[0].AssignValues(playersName[0], Player0, Indicator0, Piece0, Rank0, isPlaying[0]);
            Player[1].AssignValues(playersName[1], Player1, Indicator1, Piece1, Rank1, isPlaying[1]);
            Player[2].AssignValues(playersName[2], Player2, Indicator2, Piece2, Rank2, isPlaying[2]);
            Player[3].AssignValues(playersName[3], Player3, Indicator3, Piece3, Rank3, isPlaying[3]);

            Player[0].Name.Opacity = 1;
        }

        void SetupBoard()
        {
            for (int i = 9; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    boardPointToScore[i, j] = (9 - i) * 10 + (j + 1);
                }
                i--;
                for (int j = 9; j >= 0; j--)
                {
                    boardPointToScore[i, j] = (9 - i) * 10 + (9 - j + 1);
                }
            }

            //Assign the ladder positions
            boardPointToScore[2, 0] = 100;
            boardPointToScore[2, 9] = 91;
            boardPointToScore[4, 9] = 67;
            boardPointToScore[7, 0] = 42;
            boardPointToScore[7, 7] = 84;
            boardPointToScore[9, 0] = 38;
            boardPointToScore[9, 3] = 14;
            boardPointToScore[9, 8] = 31;

            //Assign the snake positions
            boardPointToScore[0, 2] = 79;
            boardPointToScore[0, 5] = 75;
            boardPointToScore[0, 7] = 73;
            boardPointToScore[1, 6] = 24;
            boardPointToScore[3, 1] = 19;
            boardPointToScore[3, 3] = 60;
            boardPointToScore[4, 6] = 34;
            boardPointToScore[8, 3] = 7;

            for (int i = 0; i < 100; i++)
            {
                if ((i / 10) % 2 == 0)
                {
                    boardScoreToPoint[i + 1] = ((9 - i / 10) * 10) + (i % 10);
                }
                else
                {
                    boardScoreToPoint[i + 1] = ((9 - i / 10) * 10) + (9 - i % 10);
                }
            }
            
            //Assign the ladder positions
            boardScoreToPoint[1] = 62;
            boardScoreToPoint[4] = 86;
            boardScoreToPoint[9] = 69;
            boardScoreToPoint[21] = 51;
            boardScoreToPoint[28] = 13;
            boardScoreToPoint[51] = 36;
            boardScoreToPoint[71] = 09;
            boardScoreToPoint[80] = 00;

            //Assign the snake positions
            boardScoreToPoint[98] = 21;
            boardScoreToPoint[95] = 25;
            boardScoreToPoint[93] = 27;
            boardScoreToPoint[87] = 73;
            boardScoreToPoint[62] = 81;
            boardScoreToPoint[64] = 40;
            boardScoreToPoint[54] = 66;
            boardScoreToPoint[17] = 96;
        }

        void MakeMove(int diceValue)
        {
            //if (Player[PlayerDetails.PlayerTracker].Rank.Content.ToString() == PlayerDetails.NoOfPlayers.ToString())
            if ((Player[PlayerDetails.PlayerTracker].Score > -1 || diceValue == 1) && Player[PlayerDetails.PlayerTracker].Score < 100)
            {
                Player[PlayerDetails.PlayerTracker].PieceColor.Opacity = 1;

                if (Player[PlayerDetails.PlayerTracker].Score + diceValue <= 100)
                {
                    Player[PlayerDetails.PlayerTracker].Score += diceValue;
                    if (Player[PlayerDetails.PlayerTracker].Score > 0)
                    {
                        Player[PlayerDetails.PlayerTracker].Score = boardScoreToPoint[Player[PlayerDetails.PlayerTracker].Score];
                        Player[PlayerDetails.PlayerTracker].Score = boardPointToScore[Player[PlayerDetails.PlayerTracker].Score / 10, Player[PlayerDetails.PlayerTracker].Score % 10];
                        Grid.SetRow(Player[PlayerDetails.PlayerTracker].BoardPiece, boardScoreToPoint[Player[PlayerDetails.PlayerTracker].Score] / 10 + 1);
                        Grid.SetColumn(Player[PlayerDetails.PlayerTracker].BoardPiece, boardScoreToPoint[Player[PlayerDetails.PlayerTracker].Score] % 10 + 1);
                    }

                    if (Player[PlayerDetails.PlayerTracker].Score == 100)
                    {
                        Player[PlayerDetails.PlayerTracker].Rank.Content = (++PlayerDetails.RankTracker).ToString();
                        Player[PlayerDetails.PlayerTracker].Rank.Opacity = 1;
                        Player[PlayerDetails.PlayerTracker].PieceColor.Opacity = 0.5;
                    }
                }

                if (Player[PlayerDetails.PlayerTracker].Score > 0)
                {
                    Player[PlayerDetails.PlayerTracker].BoardPiece.Opacity = 1;
                }
            }
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            if (IsNotGameOver())
            {
                Player[PlayerDetails.PlayerTracker].Name.Opacity = 0.2;

                int diceValue = getDiceValue.Next() % 6 + 1;

                this.Hide();
                diceAnimationWindow.Start(diceValue);
                diceAnimationWindow.ShowDialog();
                DisplayDice(diceValue);
                System.Threading.Thread.Sleep(200);
                MakeMove(diceValue);

                do
                {
                    PlayerDetails.PlayerTracker = ++PlayerDetails.PlayerTracker % PlayerDetails.NoOfPlayers;
                }while(Player[PlayerDetails.PlayerTracker].Score == 100);

                for(int i=0; i<PlayerDetails.NoOfPlayers; i++)
                {
                    if(Player[i].Score == 100)
                    {
                        Player[i].Name.Opacity = 0.5;
                    }
                }

                Player[PlayerDetails.PlayerTracker].Name.Opacity = 1;
            }
            else
            {
                MessageBox.Show("Game Over");
            }
        }

        bool IsNotGameOver()
        {
            int playersComplete = 0;
            for (int i = 0; i < PlayerDetails.NoOfPlayers; i++)
            {
                if (Player[i].Score == 100)
                {
                    playersComplete++;
                }
            }

            if (playersComplete == PlayerDetails.NoOfPlayers - 1)
            {
                for (int i = 0; i < PlayerDetails.NoOfPlayers; i++)
                {
                    Player[PlayerDetails.PlayerTracker].Rank.Opacity = 1;
                }
                return false;
            }
            else
            {
                return true;
            }
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            diceAnimationWindow.Close();
            Home.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch((sender as Button).Content.ToString())
            {
                case "Restart" :
                    Reset();
                    break;
                case "New":
                    Home.Show();
                    this.Close();
                    break;
            }
        }
    }
}
