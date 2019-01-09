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
    /// Interaction logic for existMother.xaml
    /// </summary>

        
    public partial class existMother : Window
    {
        BL.BL_imp bl;
        BE.Mother mother1;
        public existMother(BE.Mother mom)
        {
            mother1 = mom;
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            mainGrid.DataContext = mother1;
            
        } 





        private void apdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateMother(mother1);
                this.Close();
            }
            catch (Exception rr)
            {

                MessageBox.Show(rr.ToString());
            }


        }

        private void addChildButton_Click(object sender, RoutedEventArgs e)
        {
            newChild newChildd = new newChild();
            newChildd.Show();
            mainGrid.DataContext = mother1;
        }

        private void existChildButton_Click(object sender, RoutedEventArgs e)
        {
            existChildOfMother exist = new existChildOfMother(mother1);
            exist.Show();
        }

        private void shrchNannyButton_Click(object sender, RoutedEventArgs e)
        {
            searchNannySlider serchnannyslider = new searchNannySlider(mother1);
            serchnannyslider.Show();
        }

        private void removeMom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure that you want delete your card?", "Remove child", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        bl.removeMother(mother1);
                        MessageBox.Show("removed succeeded", "Remove mother");
                        this.Close();
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
     
        }
    }
}
