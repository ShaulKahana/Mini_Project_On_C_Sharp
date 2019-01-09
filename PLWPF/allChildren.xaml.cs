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
    /// Interaction logic for allChildren.xaml
    /// </summary>
    public partial class allChildren : Window
    {
        BL.BL_imp bl;
        IEnumerable <BE.Child> childrn;
        List<BE.Child> temp;
        public allChildren()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();


            childrn = bl.getAllChild();
            childDataGrid.DataContext = null;
            childDataGrid.DataContext = childrn;
        }


        private void search_Click_Search(object sender, RoutedEventArgs e)
        {
            try
            {
                temp = new List<BE.Child>();

                childDataGrid.DataContext = null;
                foreach (BE.Child item in childrn)
                {
                    if (item.Id == natext.Text)
                    {
                        temp.Add(item);
                    }
                }
                childDataGrid.DataContext = temp;
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
            childDataGrid.DataContext = null;
            childDataGrid.DataContext = childrn;
        }
    }
}
