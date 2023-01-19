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
            var context = new Car_RentEntities();
            var results = from c in context.Favorites
                          join c2 in context.Cars on c.ID_Car equals c2.ID_Car
                          join c3 in context.Brands on c2.ID_Brand equals c3.ID_Brand
                          select new Result {
                              Brand = c3.Name,            
                        
                        };
            FavoritesGrid.ItemsSource = results.ToArray();
        }
        private class Result {
           public string Brand { get; set; }
        
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen mainWindow = new MainScreen();
            Close();
            mainWindow.ShowDialog();
        }
    }
}
