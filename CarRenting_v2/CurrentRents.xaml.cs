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
    /// Interaction logic for CurrentRents.xaml
    /// </summary>
    public partial class CurrentRents : Window
    {
        public CurrentRents()
        {
            InitializeComponent();
            var context = new Car_RentEntities();
            DateTime date = DateTime.Now;
            var results = from c in context.Rents
                          join c2 in context.Cars on c.ID_Car equals c2.ID_Car
                          join c3 in context.Centers on c2.ID_Center equals c3.ID_Center
                          join c4 in context.Brands on c2.ID_Brand equals c4.ID_Brand
                          where c.ID_Client == Global_Client.cl.ID_Client
                          where c.DropDown_Date > date
                          select new Result() {
                              Pick_up  = c.PickUp_Date,
                              Dropdown = c.DropDown_Date,
                              Car_name = c4.Name,
                              Pickup_location = c3.Location,
                              Dropdown_location = c3.Location,
                              Price=c.Total_Price
                          };
            if (results.Count() > 0)
            {
                CurrentRentsGrid.ItemsSource = results.ToArray();
            }
        }
        private class Result {
            public DateTime Pick_up { get; set; }
            public DateTime Dropdown { get; set; }
            public string Car_name { get; set; }
            public string Pickup_location { get; set; }
            public string Dropdown_location{get;set;}
            public int Price { get; set; }


        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen mainWindow = new MainScreen();
            Close();
            mainWindow.ShowDialog();
        }
    
    }
}
