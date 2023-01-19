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
            //
            BrandCb.Items.Add("Any");
            CarTypeCb.Items.Add("Any");
            HorsePowerRangeCb.Items.Add("Any");
            YearCb.Items.Add("Any");
            ProviderCb.Items.Add("Any");
            PriceRangeCb.Items.Add("Any");
            PickUpLocationCb.Items.Add("Any");

            //
            var context = new Car_RentEntities();

            var db_brands=from c in context.Brands
                        select c;
            Brand[] brands = db_brands.ToArray();
            for (int i = 0; db_brands.Count() > i; i++)
            {
                BrandCb.Items.Add(brands[i].Name);
            }

            var db_carType = from c in context.Models
                          select c;
            Model[] models= db_carType.ToArray();
            for (int i = 0; db_carType.Count() > i; i++)
            {
                CarTypeCb.Items.Add(models[i].Name);
            }

            HorsePowerRangeCb.Items.Add("Lower than 100");
            HorsePowerRangeCb.Items.Add("100-200");
            HorsePowerRangeCb.Items.Add("200-300");
            HorsePowerRangeCb.Items.Add("300-400");
            HorsePowerRangeCb.Items.Add("Higher than 400");

            var db_provider = from c in context.Providers
                              select c;
            Provider[] providers = db_provider.ToArray();

            for (int i = 0; providers.Count() > i; i++)
            {
            ProviderCb.Items.Add(providers[i].Name);
            }

            PriceRangeCb.Items.Add("Lower than 30");
            PriceRangeCb.Items.Add("30-60");
            PriceRangeCb.Items.Add("60-90");
            PriceRangeCb.Items.Add("90-120");
            PriceRangeCb.Items.Add("Higher than 120");

            var db_pick_up=from c in context.Centers
                           select c;
            Center[] centers = db_pick_up.ToArray();
            for (int i = 0; centers.Count() > i; i++)
            {
            PickUpLocationCb.Items.Add(centers[i].Location);
            }
            for (int i = 2000; i < 2023; i++) {
            YearCb.Items.Add(i);
           
            
            }



        }
        private void Set_Components() 
        {
            //Assets/Images/driver_png.png
            if (Global_Client.cl.Path_Photo != null)
            {
                UserImage.Source = new BitmapImage(new Uri(Global_Client.cl.Path_Photo, UriKind.RelativeOrAbsolute));
            }
            TxtUsername.Text=Global_Client.cl.Username;
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
            var context = new Car_RentEntities();
            string brand;
            string car_type;
            string horse_power;
            string year;
            string pick_up;
            string price_range;
            if (BrandCb.SelectedIndex != -1)
            {
                brand = BrandCb.SelectedItem.ToString();
            }
            else {
                brand = "Any";
            }
            if (CarTypeCb.SelectedIndex != -1)
            {
                car_type = CarTypeCb.SelectedItem.ToString();
            }
            else 
            {
                car_type = "Any";
            }
            if (HorsePowerRangeCb.SelectedIndex != -1)
            {
                horse_power = HorsePowerRangeCb.SelectedItem.ToString();
            }
            else
            {
                horse_power = "Any";
            }
            if (YearCb.SelectedIndex != -1)
            {
                year = YearCb.SelectedItem.ToString();
            }
            else
            {
                year = "Any";
            }
            if (PickUpLocationCb.SelectedIndex != -1)
            {
                pick_up = PickUpLocationCb.SelectedItem.ToString();
            }
            else
            {
                pick_up = "Any";
            }
            if (PriceRangeCb.SelectedIndex != -1)
            {
                price_range = PriceRangeCb.SelectedItem.ToString();
            }
            else
            {
                price_range = "Any";
            }
            var results = from c in context.Cars
                          join c2 in context.Car_Specifications on c.ID_Car equals c2.ID_Car
                          join c3 in context.Brands on c.ID_Brand equals c3.ID_Brand
                          join c4 in context.Models on c.ID_Model equals c4.ID_Model
                          join c5 in context.Centers on c.ID_Center equals c5.ID_Center
                          select new Result {
                              ID_car = c.ID_Car,
                              Brand = c3.Name,
                              Model = c4.Name,
                              Year = c4.Year,
                              HorsePower = c2.Horse_Power,
                              Price = c2.Rental_price,
                              PickUp = c5.Location,
                              Providers=c5.Providers.ToList()
                          };
            List<Result> filtered=new List<Result>();
            for (int i = 0; i < results.Count(); i++)
            {
                int ok = 0;

                if (brand != "Any")
                    {
                        //SearchResultsGrid.ItemsSource = results.ToArray();
                        if (brand != results.ToArray()[i].Brand)
                        {
                            ok = 1;
                        }
                }
                if (car_type != "Any")
                {
                    if (car_type != results.ToArray()[i].Model)
                    {
                        ok = 1;
                    }
                }
                if (horse_power != "Any")
                {
                    if (horse_power == "Lower than 100") {
                        if (results.ToArray()[i].HorsePower > 100) { ok = 1; }
                    }
                    else if (horse_power == "100-200") {
                        if (results.ToArray()[i].HorsePower < 100|| results.ToArray()[i].HorsePower >200) { ok = 1; }
                    }
                    else if (horse_power == "200-300") {
                        if (results.ToArray()[i].HorsePower < 200 || results.ToArray()[i].HorsePower > 300) { ok = 1; }
                    }
                    else if (horse_power == "300-400") {
                        if (results.ToArray()[i].HorsePower < 300 || results.ToArray()[i].HorsePower > 400) { ok = 1; }
                    }
                    else if (horse_power == "Higher than 400") {
                        if (results.ToArray()[i].HorsePower < 400) { ok = 1; }
                    }

                }
                if (price_range != "Any")
                {
                    if (price_range == "Lower than 30")
                    {
                        if (results.ToArray()[i].Price > 30) { ok = 1; }
                    }
                    else if (price_range == "30-60")
                    {
                        if (results.ToArray()[i].Price < 30 || results.ToArray()[i].Price > 60) { ok = 1; }
                    }
                    else if (price_range == "60-90")
                    {
                        if (results.ToArray()[i].Price < 60 || results.ToArray()[i].Price > 90) { ok = 1; }
                    }
                    else if (price_range == "90-120")
                    {
                        if (results.ToArray()[i].Price < 90 || results.ToArray()[i].Price > 120) { ok = 1; }
                    }
                    else if (price_range == "Higher than 120")
                    {
                        if (results.ToArray()[i].Price < 120) { ok = 1; }
                    }

                }
                if (year != "Any") {
                    if (year != results.ToArray()[i].Year.ToString()) {
                    ok = 1;
                    }
                }
                if (pick_up != "Any") {
                    if (pick_up != results.ToArray()[i].PickUp.ToString())
                    {
                        ok = 1;
                    }
                }

                if (ok == 0) { 
                filtered.Add( results.ToArray()[i]);
                
                }
            }
            SearchResultsGrid.ItemsSource = filtered.ToArray();


        }
        class Result {
           public int ID_car { get; set; }
           public string Brand { get; set; }
           public string Model { get; set; }
           public int Year { get; set; }
           public int HorsePower { get; set; }
           public int Price { get; set; }
           public string PickUp { get; set; }
           public List<Provider> Providers { get; set; }
        }
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchResultsGrid.SelectedItem != null)
            {
                CarDetails w = new CarDetails(((Result)SearchResultsGrid.SelectedItem).ID_car);
                w.ShowDialog();
            }
            else {
                //MessageBox.Show("No item selected!");
                bool? Result = new CustomMessageBox("No item selected! Try selecting one..", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                return;

            }

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
