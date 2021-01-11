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

namespace NoughtsAndCrosses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// This array hold the current status of all the cells in the game that is being played
        /// </summary>
        private MarkType[] Results;

        /// <summary>
        /// True if it is Player 1's turn (X), false if it is Player 2's turn (0)
        /// </summary>
        private bool Player1Turn;

        /// <summary>
        /// True if the game has ended, false if the game is active or not being played.
        /// </summary>
        private bool GameEnded;

        #endregion

        #region Constructor

        /// <summary>
        /// In built constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        #endregion

        private void NewGame()
        {
            Results = new MarkType[9];

            for (var i = 0; i < Results.Length; i++)
                Results[i] = MarkType.Free;

            // This makes sure that Player 1 always starts the game
            Player1Turn = true;

            // This clears the content of the grid to make a clean grid for a new game,
            // then sets the background and text colour to the default values
            Game_Board.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            GameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // This starts a new game when you click anywhere on the grid after a game has finished
            if(GameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            #region Mark Value on Grid

            // This makes sure that if a certain cell in the grid already has a value on it, it doesn't get changed
            if (Results[index] != MarkType.Free)
                return;

            Results[index] = Player1Turn ? MarkType.Cross : MarkType.Nought;
            button.Content = Player1Turn ? "X" : "O";
            if (!Player1Turn)
                button.Foreground = Brushes.Red;

            #endregion

            // Switches between Players 1 and 2
            Player1Turn ^= true;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            #region Horizontal Wins

            if(Results[0] != MarkType.Free && (Results[0] & Results[1] & Results[2]) == Results[0])
            {
                GameEnded = true;

                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            if (Results[3] != MarkType.Free && (Results[3] & Results[4] & Results[5]) == Results[3])
            {
                GameEnded = true;

                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            if (Results[6] != MarkType.Free && (Results[6] & Results[7] & Results[8]) == Results[6])
            {
                GameEnded = true;

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            #region Vertical Wins

            if (Results[0] != MarkType.Free && (Results[0] & Results[3] & Results[6]) == Results[0])
            {
                GameEnded = true;

                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            if (Results[1] != MarkType.Free && (Results[1] & Results[4] & Results[7]) == Results[1])
            {
                GameEnded = true;

                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            if (Results[2] != MarkType.Free && (Results[2] & Results[5] & Results[8]) == Results[2])
            {
                GameEnded = true;

                Button2_0.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            #region Horizontal Wins

            if (Results[0] != MarkType.Free && (Results[0] & Results[4] & Results[8]) == Results[0])
            {
                GameEnded = true;

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            if (Results[2] != MarkType.Free && (Results[2] & Results[4] & Results[6]) == Results[2])
            {
                GameEnded = true;

                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;
            }

            #endregion

            #region No Winner

            if (!Results.Any(result => result == MarkType.Free))
            {
                GameEnded = true;

                Game_Board.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }

            #endregion
        }
    }
}
