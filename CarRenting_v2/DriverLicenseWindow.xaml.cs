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
    /// Interaction logic for DriverLicenseWindow.xaml
    /// </summary>
    public partial class DriverLicenseWindow : Window
    {
        public DriverLicenseWindow()
        {
            InitializeComponent();
            Add_items_to_comboboxes();

        }
        private void Add_items_to_comboboxes()
        {
            ClassCb.Items.Add("A");
            ClassCb.Items.Add("B");
            ClassCb.Items.Add("C");
            ClassCb.Items.Add("D");
            ClassCb.Items.Add("E");

            EyesCb.Items.Add("Amber");
            EyesCb.Items.Add("Black");
            EyesCb.Items.Add("Blue");
            EyesCb.Items.Add("Brown");
            EyesCb.Items.Add("Dark Brown");
            EyesCb.Items.Add("Gray");
            EyesCb.Items.Add("Green");
            EyesCb.Items.Add("Hazel");

            HairCb.Items.Add("Black");
            HairCb.Items.Add("Brown");
            HairCb.Items.Add("Red");
            HairCb.Items.Add("Blond");
            HairCb.Items.Add("White");

            HeightCb.Items.Add(4.1);
            HeightCb.Items.Add(4.2);
            HeightCb.Items.Add(4.3);
            HeightCb.Items.Add(4.4);
            HeightCb.Items.Add(4.5);
            HeightCb.Items.Add(4.6);
            HeightCb.Items.Add(4.8);
            HeightCb.Items.Add(4.9);
            HeightCb.Items.Add(4.10);
            HeightCb.Items.Add(4.11);
            HeightCb.Items.Add(5.1);
            HeightCb.Items.Add(5.2);
            HeightCb.Items.Add(5.3);
            HeightCb.Items.Add(5.4);
            HeightCb.Items.Add(5.5);
            HeightCb.Items.Add(5.6);
            HeightCb.Items.Add(5.8);
            HeightCb.Items.Add(5.9);
            HeightCb.Items.Add(5.10);
            HeightCb.Items.Add(5.11);
            HeightCb.Items.Add(6.1);
            HeightCb.Items.Add(6.2);
            HeightCb.Items.Add(6.3);
            HeightCb.Items.Add(6.4);

            GendreCb.Items.Add("Masculine");
            GendreCb.Items.Add("Feminine");
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen mainScreen = new MainScreen();
            Close();
            mainScreen.ShowDialog();
        }

       
    }
}
