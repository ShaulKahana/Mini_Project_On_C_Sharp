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
    /// Interaction logic for existChildOfMother.xaml
    /// </summary>
    public partial class existChildOfMother : Window
    {
        BL.BL_imp bl;
        IEnumerable<BE.Child> childOfMOM;
        BE.Mother mom2 = new BE.Mother();
        public existChildOfMother(BE.Mother mom)
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            mom2 = mom;

            childOfMOM = bl.getChildOfMother(mom);
            childDataGrid.DataContext = null;
            childDataGrid.DataContext = childOfMOM;
        }



        private void showDetaildOfChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bl.searchChild(idBox.Text) == null)
                     MessageBox.Show("The child still does not exist in the system");

                else
                {
                    childDetails cd = new childDetails(bl.searchChild(idBox.Text));
                    cd.Show();
                }
            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
        }
    }
}
