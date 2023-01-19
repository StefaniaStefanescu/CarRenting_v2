using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void BackLogginButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.ShowDialog();
        }
        public static bool isValid_DateTime(string str)
        {
            string pattern = @"^\d{4}-\d{2}-\d{2}$";
            return Regex.IsMatch(str, pattern);
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            var username=txtUsername.Text.ToString();
            var context = new Car_RentEntities();
            
           var results = from c in context.Clients
                              where c.Username.Equals(username)
                              select c;
                if (results.Count() > 0)
                {
                    
                    bool? Result = new CustomMessageBox("Error Name Already in use!", MessageType.Error, MessageButtons.Ok).ShowDialog();

                    return;
                }

            
            var password =txtPassword.Password.ToString();
            var birthDate=DateTime.ParseExact(txtBirthDate.Text,"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            if (username.Count() < 4 || password.Count() < 4)
            {
                //MessageBox.Show("Password or Username too short(Minimum 4 characters)");
                bool? Result = new CustomMessageBox("Password or Username too short(Minimum 4 characters) ", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                return;
            }
            var newClient = new Client()
            {
            Birth_date=birthDate,
            Username=username,
            Password=password
            };

            //

                       context.Clients.Add(newClient);
                       context.SaveChanges();
                       var inserted_client = (from c in context.Clients
                                       where c.Username == username
                                       select c).First();

            Global_Client.cl = inserted_client;

 //
            DriverLicenseWindow newWindow = new DriverLicenseWindow(inserted_client.ID_Client);
            Close();
            newWindow.ShowDialog();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

       
    }
}
