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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for existNanny.xaml
    /// </summary>
    /// 
 
    public partial class existNanny : Window
    {
        BL.BL_imp bl;
        BE.Nanny nanny = new BE.Nanny();
        public existNanny(BE.Nanny nanny1)
        {
            nanny = nanny1;
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            mainGrid.DataContext = nanny;
        }

        private void updateNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateNanny(nanny);
                this.Close();


            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
           
        }



        private void existChildButton_Click(object sender, RoutedEventArgs e)
        {
            existChildOfNanny exist = new existChildOfNanny(nanny);
            exist.Show();
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure that you want delete your card?", "Remove nanny", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        bl.removeNanny(nanny);
                        MessageBox.Show("removed succeeded", "Remove nanny");
                        this.Close();
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
   
        }

        private void vacationOfMisradHinuhCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            vacationOfTamatCheckBox.IsChecked = false;
        }

        private void vacationOfTamatCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            vacationOfMisradHinuhCheckBox.IsChecked = false;
        }
    }
}
