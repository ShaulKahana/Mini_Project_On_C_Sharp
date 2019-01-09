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
    /// Interaction logic for showContractDetails.xaml
    /// </summary>
    public partial class showContractDetails : Window
    {
        BL.BL_imp bl;
        BE.Contract contract;
        public showContractDetails(BE.Contract contract1)
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            contract = contract1;
            this.maingrid.DataContext = contract1;
            this.grid1.DataContext = contract1;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            bl.updateContract(contract);
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(contract != null)
            bl.removeContract(contract);
            this.Close();
        }
    }
}
