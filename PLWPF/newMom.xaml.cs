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
    /// Interaction logic for newMom.xaml
    /// </summary>
    public partial class newMom : Window
    {
        BL.BL_imp bl;
        BE.Mother mom ;
        public newMom()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            mom = new BE.Mother();
            this.mainGrid.DataContext = mom; 
        }



        private void addMomButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addMother(mom);
                this.Close();
            }
            catch (Exception rr)
            {

                MessageBox.Show(rr.ToString());
            }
        }
    }
}
