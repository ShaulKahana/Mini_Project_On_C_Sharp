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
    /// Interaction logic for Maniger_UserName.xaml
    /// </summary>
    public partial class Maniger_UserName : Window
    {
        public Maniger_UserName()
        {
            InitializeComponent();
        }

        private void enterToSystem_Click(object sender, RoutedEventArgs e)
        {
            if (this.idBox.Text == "021956511" && this.passwordBox.Password == "1234")
            {
                Manager manager = new Manager();
                manager.Show();
            }
            else
                MessageBox.Show("incorct detils");
        }
    }
}
