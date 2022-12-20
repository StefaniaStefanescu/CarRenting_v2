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
    /// Interaction logic for FavouritesScreen.xaml
    /// </summary>
    public partial class FavouritesScreen : Window
    {
        public FavouritesScreen()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen mainWindow = new MainScreen();
            Close();
            mainWindow.ShowDialog();
        }
    }
}
