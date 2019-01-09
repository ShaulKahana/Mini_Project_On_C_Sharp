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
    /// Interaction logic for newNanny.xaml
    /// </summary>
    public partial class newNanny : Window
    {
        BL.BL_imp bl;
        BE.Nanny nny;
        public newNanny()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            nny = new BE.Nanny();
            this.mainGrid.DataContext = nny;
        }

 

        private void addNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addNanny(nny);
                this.Close();
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
