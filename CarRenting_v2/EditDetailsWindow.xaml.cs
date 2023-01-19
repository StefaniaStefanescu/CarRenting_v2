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
    /// Interaction logic for EditDetailsWindow.xaml
    /// </summary>
    public partial class EditDetailsWindow : Window
    {
        public EditDetailsWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen mainWindow = new MainScreen();
            Close();
            mainWindow.ShowDialog();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string newUser=txtUsername.Text.ToString();
            string oldPass=txtOldPassword.Password.ToString();
            string newPass=txtNewPassword.Password.ToString();

            if (newPass.Length < 4)
            {
                bool? Result = new CustomMessageBox("Username is too short!", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
            if (newPass.Length < 4) {
                bool? Result = new CustomMessageBox("Password is too short!", MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
            
            var context = new Car_RentEntities();
            if (!newUser.Equals( Global_Client.cl.Username.ToString()))
            {
                var results = from c in context.Clients
                              where c.Username.Equals(newUser)
                              select c;
                if (results.Count() > 0)
                {

                    bool? Result = new CustomMessageBox("Error Name Already in use!", MessageType.Error, MessageButtons.Ok).ShowDialog();

                    return;
                }
            }
            var updated_Client=(from c in context.Clients
                                where Global_Client.cl.ID_Client == c.ID_Client
                                select c).First();
            if (oldPass == Global_Client.cl.Password)
            {
                updated_Client.Password = newPass;
                updated_Client.Username = newUser;
                Global_Client.cl.Password = newPass;
                Global_Client.cl.Username = newUser;
                context.SaveChanges();
                return;
            }
            else {
                //MessageBox.Show("Wrong Old Password");
                bool? Result = new CustomMessageBox("Wrong OLD password!", MessageType.Warning, MessageButtons.Ok).ShowDialog();

            }

        }
    }
}
