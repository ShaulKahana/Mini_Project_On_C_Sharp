using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PLWPF
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.BL_imp bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
          

            slider.ToolTip = new ToolTip();
            slider.ToolTip = slider.Value;

        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            slider.ToolTip = (int)slider.Value;
        }


        private void motherButton_Click(object sender, RoutedEventArgs e)
        {
            mother mom = new mother();
            mom.Show();

        }

        private void nannyButton_Click(object sender, RoutedEventArgs e)
        {
            nanny nanny = new nanny();
            nanny.Show();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                closeDistanceNannies closeDistanceNannies = 
                    new closeDistanceNannies(this.textBox.Text, (int)this.slider.Value);
                 closeDistanceNannies.Show();
                 this.textBox.Clear();


            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }
           
      
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            Maniger_UserName manager = new Maniger_UserName();
            manager.Show();
        }
    }
}
