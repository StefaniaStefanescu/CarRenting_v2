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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;


namespace CarRenting_v2
{
    static class Global_Client {
        public static Client cl;
    
    }
    static class Global_Rent
    {
        public static Rent rt;

    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Global_Rent.rt = new Rent();
            InitializeComponent();
        }
         
        public bool IsDarkTheme { get; set; }
        public readonly PaletteHelper paletteHelper = new PaletteHelper();
        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);

            }
            else {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow newwindow = new RegisterWindow();
            Close();
            newwindow.ShowDialog();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Car_RentEntities())
            {
                var username = txtUsername.Text.ToString();
                var password = txtPassword.Password.ToString();
                var results = from c in context.Clients
                              where c.Username.Equals (username)&& c.Password.Equals (password)
                              select c;
                if (results.Count() == 0) {

                  //  MessageBox.Show("No user found!");
                    bool? Result = new CustomMessageBox("No user was found. Try again ? ", MessageType.Warning, MessageButtons.Ok).ShowDialog();

                    return;
                }
                Global_Client.cl = results.First();

                    MainScreen newWindow = new MainScreen();
                    Close();
                    newWindow.ShowDialog();


            
            
            }
        }
    }
}
