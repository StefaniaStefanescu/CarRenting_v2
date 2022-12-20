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
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Window
    {
        public MainScreen()
        {
            InitializeComponent();
            Set_Components();
        }
        private void Set_Components() 
        {
            //Assets/Images/driver_png.png
            UserImage.Source = new BitmapImage(new Uri(@"Assets/Images/driver_png.png", UriKind.RelativeOrAbsolute));
            TxtUsername.Text = "Nia";
        }
        private void EditDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            EditDetailsWindow newwindow=new EditDetailsWindow();
            Close();
            newwindow.ShowDialog();
        }

        private void MyHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            HistoryScreen newwindow = new HistoryScreen();
            Close();
            newwindow.ShowDialog();
        }

        private void CurrentRentsButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentRents mainWindow = new CurrentRents();
            Close();
            mainWindow.ShowDialog();
        }

        private void FavouritesButton_Click(object sender, RoutedEventArgs e)
        {
            FavouritesScreen mainWindow = new FavouritesScreen();
            Close();
            mainWindow.ShowDialog();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ApplyFiltersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            CarDetails w = new CarDetails();
            w.ShowDialog();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
