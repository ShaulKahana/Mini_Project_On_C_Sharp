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
    /// Interaction logic for newChild.xaml
    /// </summary>
    public partial class newChild : Window
    {
        BL.BL_imp bl;
        BE.Child Child ;
        public newChild()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            Child = new BE.Child();
            grid1.DataContext = Child;
            grid2.DataContext = Child;
            grid3.DataContext = Child;
        }

        private void addChildButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addChild(Child);
                this.Close();
            }
            catch (Exception r)
            {

                MessageBox.Show(r.Message);
            }

           
        }
    }
}
