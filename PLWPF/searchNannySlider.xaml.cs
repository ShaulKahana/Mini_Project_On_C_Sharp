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
    /// Interaction logic for serchNannySlider.xaml
    /// </summary>
    public partial class searchNannySlider : Window
    {
        BL.BL_imp bl;
        BE.Mother mathr;
        public searchNannySlider(BE.Mother mom)
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            mathr = mom;

            slider.ToolTip = new ToolTip();
            slider.ToolTip = slider.Value;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider.ToolTip = (int)slider.Value;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 matchNannies Nannies = new matchNannies(mathr, (int)this.slider.Value);
                  Nannies.Show();

            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
          

        }

    }
}
