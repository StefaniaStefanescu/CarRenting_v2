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
    /// Interaction logic for RentStep1.xaml
    /// </summary>
    public partial class RentStep1 : Window
    {
        public RentStep1()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ChoosePaymentMethodWindow w=new ChoosePaymentMethodWindow();
            Close();
            w.ShowDialog();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            CarDetails w = new CarDetails();
            Close();
            w.ShowDialog();
        }
    }
}
