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
    /// Interaction logic for allMathers.xaml
    /// </summary>
    public partial class allMathers : Window
    {
        BL.BL_imp bl;

        IEnumerable<BE.Mother> Mather;
        List<BE.Mother> temp;
        public allMathers()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            Mather = bl.getAllMothers();
            motherDataGrid.DataContext = null;
            motherDataGrid.DataContext = Mather;
        }

        private void searchButton_Click_Search(object sender, RoutedEventArgs e)
        {
            try
            {
                temp = new List<BE.Mother>();

                motherDataGrid.DataContext = null;
                foreach (BE.Mother item in Mather)
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


        private void refreshList_Click_Restart(object sender, RoutedEventArgs e)
        {
            motherDataGrid.DataContext = null;
            motherDataGrid.DataContext = Mather;
        }
    }
}

