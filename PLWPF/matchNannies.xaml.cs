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
    /// Interaction logic for matchNannies.xaml
    /// </summary>
    public partial class matchNannies : Window
    {
        BE.Mother momTemp;
        BL.BL_imp bl;
        List<BE.Nanny> temp;
        IEnumerable<BE.Nanny> Nanny;
        public matchNannies(BE.Mother mom, int distance)
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            temp = new List<BE.Nanny>();
            momTemp = mom;
            temp = bl.getMatchNanniesList(mom);
            Nanny = bl.closeDistanceNannies(mom, distance, temp);
            motherDataGrid.DataContext = null;
            motherDataGrid.DataContext = Nanny;
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            try
            {
                temp = new List<BE.Nanny>();

                motherDataGrid.DataContext = null;
                foreach (BE.Nanny item in Nanny)
                {
                    if (item.Id == natext.Text)
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


        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            motherDataGrid.DataContext = null;
            motherDataGrid.DataContext = Nanny;
        }

        private void newContract_Click(object sender, RoutedEventArgs e)
        {
            showNannyDetails Details = new showNannyDetails(natext.Text, momTemp);
            Details.Show();
        }
    }
}
