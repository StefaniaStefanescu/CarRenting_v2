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

namespace CarRenting_v2
{
    /// <summary>
    /// Interaction logic for MessageBoxMD.xaml
    /// </summary>
    public partial class MessageBoxMD : Window
    {
        public MessageBoxMD()
        {
            InitializeComponent();
        }

        private void OKbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
