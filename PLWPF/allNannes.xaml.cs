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
    /// Interaction logic for allNannes.xaml
    /// </summary>
    public partial class allNannes : Window
    {
        BL.BL_imp bl;

        IEnumerable<BE.Nanny> Nannes;
        List<BE.Nanny> temp;
        public allNannes()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            Nannes = bl.getAllNannies();
            motherDataGrid.DataContext = null;
            motherDataGrid.DataContext = Nannes;
        }

        private void searchButton_Click_Search(object sender, RoutedEventArgs e)
        {
            try
            {
                temp = new List<BE.Nanny>();

                motherDataGrid.DataContext = null;
                foreach (BE.Nanny item in Nannes)
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
            motherDataGrid.DataContext = Nannes;
        }
    }
}
