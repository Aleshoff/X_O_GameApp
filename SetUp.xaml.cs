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
    /// Interaction logic for SetUp.xaml
    /// </summary>
    public partial class SetUp : Page
    {
        private bool rbtnPrevState;
        public SetUp()
        {
            InitializeComponent();
            rbtnPrevState = this.btnRadio.IsChecked.Value;
        }

        private void mnuDespre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageDespre());
        }

        private void btnRadio_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rbt = sender as RadioButton;
            if (rbtnPrevState == false)
            {
                rbt.IsChecked = true;
                rbtnPrevState = true;
            }
            else
            {
                rbt.IsChecked = false;
                rbtnPrevState = false;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMenu());
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("You didn't enter any name! Please retry!");
                return;
            }
            
            Game game = new Game(txtName.Text.Trim(), rbtnPrevState);
           
            NavigationService.Navigate(new PageBoard(game));

        }

    }
}
