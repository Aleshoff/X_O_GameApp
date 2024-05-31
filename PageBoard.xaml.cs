using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace X_O_GameApp
{
    /// <summary>
    /// Interaction logic for PageBoard.xaml
    /// </summary>
    public partial class PageBoard : Page
    {
        private Game game;
        private bool isButtonClicked = false;
        
        public PageBoard(Game game)
        {
            InitializeComponent();
            this.game = game;
            txtUserMove.Text = game.getName() + "'s movement";
        }

        private void mnuDespre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageDespre());
        }

        private void mnuStartJoc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SetUp());
        }

        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            if(!isButtonClicked)
            {
                game.UserWon += Game_UserWon;
                game.ComputerWon += Game_ComputerWon;
                game.Draw += Game_Draw;
                //game.gameOver();

                txtCompMove.Text = "Computer's movement";
                txtUserMove.Text = "";
                isButtonClicked = true;

                Button currentButton = (Button)sender;
                string btnName = currentButton.Name;
                int i = btnName[3] - 48;
                int j = btnName[4] - 48;
                int value = game.getIsXPlayer() ? 3 : 0;
                game.setField(i, j, value);
                updateBoard();
                game.gameOver();
                if (game.isGameOver)
                    return;
                
                game.UserWon -= Game_UserWon;
                game.Draw -= Game_Draw;
                

                await Task.Delay(1000);

                game.setFieldComputer();
                updateBoard();
                game.gameOver();
                game.ComputerWon -= Game_ComputerWon;

                isButtonClicked = false;
                txtCompMove.Text = "";
                txtUserMove.Text = game.getName() + "'s movement";
            } 
        }

        private void Game_Draw()
        {
            MessageBox.Show("Draw!");
            NavigationService.Navigate(new PageMenu());
        }

        private void Game_UserWon()
        {
            MessageBox.Show(game.getName() + " won!");
            NavigationService.Navigate(new PageMenu());
        }

        private void Game_ComputerWon()
        {
            MessageBox.Show(game.getName() +  " lost!", game.getName());
            NavigationService.Navigate(new PageMenu());
        }

        private Button findButton(int i, int j)
        {
            Button button = new Button();
            string buttonName = "btn" + i + j;

            foreach (UIElement el in grdBoard.Children)
            {
                if (el.GetType() == typeof(Button))
                {
                    Button buttonTemp = (Button)el;

                    if (buttonTemp.Name.Equals(buttonName))
                    {
                        button = buttonTemp;
                    }
                }
            }

            return button;
        }      
        private void updateBoard ()
        {
            int[,] newBoard = game.getBoard();
            
            for(int i = 0; i < newBoard.GetLength(0); i++)
            {
                for(int j = 0; j < newBoard.GetLength(1); j++)
                {
                    if(newBoard[i,j] != -1)
                    {
                        Button button = findButton(i, j);
                        button.Content = newBoard[i, j] == 3 ? "X" : "0";
                        button.IsEnabled = false;
                    }
                }
            }
        }
    }
}
