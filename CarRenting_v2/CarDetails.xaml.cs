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
        public int car_ID { get; set; }
        public CarDetails(int car_id)
        {
            car_ID = car_id;
            var context = new Car_RentEntities();
            InitializeComponent();
            Set_components();
            var results = from c in context.Cars
                          join c2 in context.Car_Specifications on c.ID_Car equals c2.ID_Car
                          join c3 in context.Brands on c.ID_Brand equals c3.ID_Brand
                          join c4 in context.Models on c.ID_Model equals c4.ID_Model
                          where c.ID_Car .Equals(car_ID)
                          select new
                          {
                              ID_car = c.ID_Car,
                              Brand_Country=c3.Country,
                              Brand_Founder=c3.Founder,
                              Brand_Motto=c3.Motto,
                              Brand = c3.Name,
                              Model = c4.Name,
                              Model_year = c4.Year,
                              Production_Year = c4.Year,
                              HorsePower = c2.Horse_Power,
                              Price = c2.Rental_price,
                          };
            CurrentRentsGrid.ItemsSource = results.ToList();
        }

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            RentStep1 w=new RentStep1(car_ID);
            Close();
            w.ShowDialog();
            
        }
        private void Set_components()
        {
            var context = new Car_RentEntities();
            Car res = (from c in context.Cars
                      where c.ID_Car == car_ID
                      select c).First();
            CarImage.Source = new BitmapImage(new Uri(res.Path_Photo, UriKind.RelativeOrAbsolute));
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FavBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new Car_RentEntities();
            Favorite fav = new Favorite() {
                ID_Car = car_ID,
                ID_Client = Global_Client.cl.ID_Client,
                Add_Date = DateTime.Now
            };
            var results= from c in context.Favorites
                         where c.ID_Car==car_ID && c.ID_Client==Global_Client.cl.ID_Client
                         select c;
            if (results.Count() == 0)
            {
                context.Favorites.Add(fav);
                context.SaveChanges();
               // MessageBox.Show("Noice!");
            }
            else {
               // MessageBox.Show("Already added");
                return;
            
            }
        }
    }
}
