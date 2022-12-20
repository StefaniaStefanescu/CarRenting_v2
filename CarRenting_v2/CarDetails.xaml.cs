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
    /// Interaction logic for CarDetails.xaml
    /// </summary>
    public partial class CarDetails : Window
    {
        public CarDetails()
        {
            InitializeComponent();
            Set_components();
        }

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            RentStep1 w=new RentStep1();
            Close();
            w.ShowDialog();
            
        }
        private void Set_components()
        {
            
            CarImage.Source= new BitmapImage(new Uri(@"Assets/Cars/car1.jpg", UriKind.RelativeOrAbsolute));
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
