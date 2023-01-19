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
        private int client_id;
        public DriverLicenseWindow(int id)
        {
            client_id = id;
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
            var context = new Car_RentEntities();
            var client = (from c in context.Clients
                         where c.ID_Client == client_id
                         select c).First();
            context.Clients.Remove(client);
            context.SaveChanges();
            Application.Current.Shutdown();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var context = new Car_RentEntities();
            string driver_id=txtDriverID.Text.ToString();
            string gender = GendreCb.Text.ToString();
            string newClass=ClassCb.Text.ToString();
            string hairColor=HairCb.Text.ToString();
            string eyesColor=EyesCb.Text.ToString();
            double height = Convert.ToDouble(HeightCb.Text.ToString());
            var results = from c in context.Driver_License
                          where c.DriverID.Equals(driver_id)
                              select c;
            if (results.Count() > 0)
            {
                //MessageBox.Show("Error Driver ID in use!");
                bool? Result = new CustomMessageBox("Driver ID already in use!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }

            var newDriver_License = new Driver_License() {
                Class = newClass,
                DriverID = driver_id,
                Gender = gender,
                HairColor = hairColor,
                EyesColor = eyesColor,
                Height = height           
            };
            //Global_Client.cl.Driver_License.Add(newDriver_License);
            var myClient=(from c in context.Clients
                         where c.ID_Client.Equals(Global_Client.cl.ID_Client)
                         select c).First();
           // context.Clients.FirstOrDefault(x => x.ID_Client==myClient.ID_Client).Driver_License.Add(newDriver_License);
           // myClient.Driver_License.Add(newDriver_License);
            //myClient = Global_Client.cl;
            context.Driver_License.Add(newDriver_License);
            context.SaveChanges();
            Client_Licenses xer = new Client_Licenses()
            {
                ID_Client = Global_Client.cl.ID_Client,
                ID_License = newDriver_License.ID_License


            };
            context.Client_Licenses.Add(xer);
            context.SaveChanges();
         //   var d_id = (from c in context.Driver_License
         //                   where c.DriverID == driver_id
         //                   select c).First();

           // var connection = new Client_Licenses()
           // {
           //     ID_Client = client_id,
          //     ID_License = d_id.ID_License
           // };
            //context.Client_Licenses.Add(connection);

            MainScreen mainScreen = new MainScreen();
            Close();
            mainScreen.ShowDialog();
        }

        private void txtDriverID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
