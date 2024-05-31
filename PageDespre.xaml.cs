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

namespace X_O_GameApp
{
    /// <summary>
    /// Interaction logic for PageDespre.xaml
    /// </summary>
    public partial class PageDespre : Page
    {
        public string date { get; set; }
        public PageDespre()
        {
            InitializeComponent();
            Date.Text = "Date: " + DateTime.Now.ToString("D");
            Rules.Text = "Rules: Players take turns putting their marks in empty squares. " +
                "The first player to get 3 of his marks in a row (up, down, across, or diagonally) is the winner. " +
                "When all 9 squares are full, the game is over. If no player has 3 marks in a row, the game ends in a tie.";
        }

        

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMenu());
        }

        private void mnuDespre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageDespre());
        }

        private void mnuStartJoc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SetUp());
        }
    }
}
