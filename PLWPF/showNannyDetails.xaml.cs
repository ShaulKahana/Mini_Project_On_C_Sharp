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
    /// Interaction logic for showNannyDetails.xaml
    /// </summary>
    public partial class showNannyDetails : Window
    {
        BE.Nanny newnan;
        BL.BL_imp bl;
        BE.Mother mom;
        public showNannyDetails(string idNanny, BE.Mother mm)
        {
            InitializeComponent();
            mom = mm;
            bl = BL.FactoryBL.getBL();
            newnan = bl.searchNanny(idNanny);
            this.mainGrid.DataContext = newnan;
            this.grid29.DataContext = newnan;
            this.grid28.DataContext = newnan;
            this.grid2.DataContext = newnan;
            this.grid26.DataContext = newnan;
            this.grid7.DataContext = newnan;
            this.grid27.DataContext = newnan;
            this.grid35.DataContext = newnan;
        }

        private void contract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                   Contract Con = new Contract(newnan, mom);
                    Con.Show();
            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
         
        }

        private void maxAgeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
