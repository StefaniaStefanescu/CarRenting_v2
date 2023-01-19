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
        public int car_ID { get; set; }

        public RentStep1(int id)
        {
            car_ID=id;
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Pick_upCalendar.SelectedDate.HasValue||!Drop_downCalendar.SelectedDate.HasValue) {
                //MessageBox.Show("No date selected found!");
                bool? Result = new CustomMessageBox("No date selected found!", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                return;
            }
            var context = new Car_RentEntities();
            var result= (from c in context.Cars
                         join c2 in context.Car_Specifications on c.ID_Car equals c2.ID_Car
                        select new {
                        ID_Center=c.ID_Center,
                        Price=c2.Rental_price
                        
                        }).First();
            Global_Rent.rt.ID_Car = car_ID;
            Global_Rent.rt.PickUp_Date = (Pick_upCalendar.SelectedDate.Value);
            Global_Rent.rt.DropDown_Date = (Drop_downCalendar.SelectedDate.Value);
            if (Global_Rent.rt.PickUp_Date > Global_Rent.rt.DropDown_Date) {
                //MessageBox.Show("Pickup is after drop down :)!");
                bool? Result = new CustomMessageBox("Pickup is after drop down!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;

            }
            var compare_dates = from c in context.Rents
                                where c.ID_Car == car_ID
                                select new
                                {
                                    c.PickUp_Date,
                                    c.DropDown_Date
                                };
            for (int i = 0; i < compare_dates.Count(); i++) {
                if (compare_dates.ToArray()[i].PickUp_Date <= Global_Rent.rt.PickUp_Date
                    && compare_dates.ToArray()[i].DropDown_Date >= Global_Rent.rt.PickUp_Date) {
                    //MessageBox.Show("Already used that date,try another :) !");
                    bool? Result = new CustomMessageBox("Already used that date,try another :) !", MessageType.Error, MessageButtons.Ok).ShowDialog();

                    return; }
                if (compare_dates.ToArray()[i].PickUp_Date<= Global_Rent.rt.DropDown_Date
    && compare_dates.ToArray()[i].DropDown_Date >= Global_Rent.rt.DropDown_Date)
                {
                    //MessageBox.Show("Already used that date,try another :) !");
                    bool? Result = new CustomMessageBox("Already used that date,try another :) !", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    return;
                }

            }
            Global_Rent.rt.ID_Client = Global_Client.cl.ID_Client;
            Global_Rent.rt.PickUp_Location_ID = result.ID_Center;
            Global_Rent.rt.DropDown_Location_ID = result.ID_Center;
            Global_Rent.rt.Total_Price = ((int)(Global_Rent.rt.DropDown_Date-Global_Rent.rt.PickUp_Date).TotalDays)*result.Price;
            ChoosePaymentMethodWindow w=new ChoosePaymentMethodWindow(car_ID);
            Close();
            w.ShowDialog();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            CarDetails w = new CarDetails(car_ID);
            Close();
            w.ShowDialog();
        }
    }
}
