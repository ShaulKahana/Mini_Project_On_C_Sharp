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
    /// Interaction logic for allContracts.xaml
    /// </summary>
    public partial class allContracts : Window
    {
        BL.BL_imp bl;

        IEnumerable<BE.Contract> Contract;
        List<BE.Contract> temp;
        public allContracts()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            Contract = bl.getAllContract();
            motherDataGrid.DataContext = null;
            motherDataGrid.DataContext = Contract;
        }

        private void searchButton_Click_Search(object sender, RoutedEventArgs e)
        {
            try
            {
                temp = new List<BE.Contract>();

                motherDataGrid.DataContext = null;
                foreach (BE.Contract item in Contract)
                {
                    if (item.ContractNum.ToString() == natext.Text)
                    {
                        temp.Add(item);
                    }
                }
                motherDataGrid.DataContext = temp;
            }
            catch (Exception r)
            {
                if (r == null)
                {
                    MessageBox.Show("Too many requests per minute or input is incorrect");
                }
                MessageBox.Show(r.Message);
            }

        }


        private void refreshList_Click_Restart(object sender, RoutedEventArgs e)
        {
            motherDataGrid.DataContext = null;
            motherDataGrid.DataContext = Contract;
        }
    }
}
