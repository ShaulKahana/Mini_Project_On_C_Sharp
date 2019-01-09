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
    /// Interaction logic for xsistChild.xaml
    /// </summary>
    public partial class existChildOfNanny : Window
    {
        BL.BL_imp bl;
       
       IEnumerable<BE.Child> childOfNanny;

        BE.Contract contract = new BE.Contract();
        BE.Nanny nanny;
        public existChildOfNanny(BE.Nanny nanny1)
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
           
            nanny = nanny1;
            childOfNanny = bl.getChildOfNanni(nanny);
            childDataGrid.DataContext = null;
            childDataGrid.DataContext = childOfNanny;
        }

        private void showDetaildOfChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BE.Child c = bl.searchChild(idBox.Text);
                contract = bl.searchContract(c.ContractNum);
                if (contract != null)
                {
                    showContractDetails showcontractDetails = new showContractDetails(contract);
                    showcontractDetails.Show();
                }
            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
        }


    }
}
