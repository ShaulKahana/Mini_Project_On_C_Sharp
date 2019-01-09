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
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        BL.BL_imp bl;

   
        public Manager()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
        }

        private void allNannes_Click(object sender, RoutedEventArgs e)
        {
            allNannes all = new allNannes();
            all.Show();
        }

        private void allMathers_Click(object sender, RoutedEventArgs e)
        {
            allMathers all = new allMathers();
            all.Show();
        }

        private void allChildren_Click(object sender, RoutedEventArgs e)
        {
            allChildren all = new allChildren();
            all.Show();
        }

        private void allContracts_Click(object sender, RoutedEventArgs e)
        {
            allContracts all = new allContracts();
            all.Show();
        }

        private void childrenWithoutNannis_Click(object sender, RoutedEventArgs e)
        {
            childrenWithoutNannis all = new childrenWithoutNannis();
            all.Show();
        }

        private void nanniesWithTamat_Click(object sender, RoutedEventArgs e)
        {
            nanniesWithTamat all = new nanniesWithTamat();
            all.Show();
        }

 
    }
}
