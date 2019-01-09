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
    /// Interaction logic for Contract.xaml
    /// </summary>
    public partial class Contract : Window
    {
        BL.BL_imp bl;
        BE.Contract contract;
        public Contract(BE.Nanny nanny1, BE.Mother mom)
        {
            InitializeComponent();
            startWorkDateDatePicker.SelectedDate = DateTime.Today;
            endWorkDateDatePicker.SelectedDate = DateTime.Today;
            bl = BL.FactoryBL.getBL();
            contract = new BE.Contract();
            Label1.Content = mom.Id;
            idOfNannyLabel.Content = nanny1.Id;
            contract.IdOfMother = mom.Id;
            contract.IdOfNanny = nanny1.Id;

            this.grid1.DataContext = contract;
        }



        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addContract(contract);
                showContractDetails showcontractDetails = new showContractDetails(contract);
                showcontractDetails.Show();
                this.Close();
            }
            catch (Exception rr)
            {

                MessageBox.Show(rr.Message);
            }
        }
    }
}
