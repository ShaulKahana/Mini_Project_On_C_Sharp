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
    /// Interaction logic for mother.xaml
    /// </summary> 
    /// 
    public partial class mother : Window
    { BL.BL_imp bl;
        public mother()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
        }


        private void enterToSystem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BE.Mother temp = null;
                    temp = bl.searchMother(this.idBox.Text);
                
                if(temp==null)
                    throw(new Exception("no exist"));
                
                if (temp.Password != this.passwordBox.Password)
                    throw (new Exception("Incorrect password"));
     
                    existMother exstMom = new existMother(temp);
                    exstMom.Show();
                    this.idBox.Clear();
                    this.passwordBox.Clear();

            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
           
        }

        
        private void newMom_Click(object sender, RoutedEventArgs e)
        {
            newMom m = new newMom();
            m.Show();
        }
    }
}
