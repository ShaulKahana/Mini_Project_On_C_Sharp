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
    /// Interaction logic for childDetails.xaml
    /// </summary>
    public partial class childDetails : Window
    {
        BL.BL_imp bl;
        BE.Child childTemp;
        BE.Contract contract = new BE.Contract();
        public childDetails(BE.Child temp)
        {
            childTemp = temp;
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            mainGrid.DataContext = temp;

        }


      
        private void updateChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateChild(childTemp);
                this.Close();
            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
        }

        private void removeChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure that you want to delete this child?", "Remove child", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        bl.removeChild(childTemp);
                        MessageBox.Show("The child is removed", "Remove child");
                        break;

                    case MessageBoxResult.No:
                        MessageBox.Show("The child dont removed", "Remove child");
                        break;
                }


            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }

        private void showDetaildOfChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contract = bl.searchContract(childTemp.ContractNum);
                if (contract != null)
                {
                    showContractDetails showcontractDetails = new showContractDetails(contract);
                    showcontractDetails.Show();
                }
                else
                    throw new Exception("The contract is not exist in the system");
            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
        }
    }
}
