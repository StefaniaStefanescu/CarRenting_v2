using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for CardWindow.xaml
    /// </summary>
    public partial class CardWindow : Window
    {
        public CardWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen w = new MainScreen();
            Close();
            w.ShowDialog();
        }

        public static bool IsValidDate(string date)
        {
            string pattern = @"^(\d{4})-(\d{2})-(\d{2})$";
            Match match = Regex.Match(date, pattern);
            if (!match.Success)
                return false;

            int year = int.Parse(match.Groups[1].Value);
            int month = int.Parse(match.Groups[2].Value);
            int day = int.Parse(match.Groups[3].Value);

            return IsValidYear(year) && IsValidMonth(month) && IsValidDay(year, month, day);
        }

        private static bool IsValidYear(int year)
        {
            return year >= 1 && year <= 9999;
        }

        private static bool IsValidMonth(int month)
        {
            return month >= 1 && month <= 12;
        }

        private static bool IsValidDay(int year, int month, int day)
        {
            int[] daysPerMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (day < 1 || day > daysPerMonth[month])
                return false;

            if (month == 2 && day == 29 && !IsLeapYear(year))
                return false;

            return true;
        }

        private static bool IsLeapYear(int year)
        {
            if (year % 4 != 0)
                return false;

            if (year % 100 == 0 && year % 400 != 0)
                return false;

            return true;
        }

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtCardNumber.Text.Length == 0 || txtCardName.Text.Length == 0 || txtCardCvv.Text.Length == 0 || txtCardExp.Text.Length == 0) 
            {
                //MessageBox.Show("Not all textboxes completed!");
                bool? Result = new CustomMessageBox("Not all information completed!", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                return;
            }
            var context = new Car_RentEntities();
            Credit_Card cd= new Credit_Card();
            /*if (IsValidDate(txtCardExp.ToString())==false){
                bool? Result = new CustomMessageBox("Incorrect date format!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }*/

            //ITEXTSHARP CRYSTALREPORTS pentru facturare
            
            //cd.EXP = DateTime.Parse(txtCardExp.Text.ToString());
            try{
                cd.EXP = DateTime.Parse(txtCardExp.Text.ToString());
            }
            catch{
                bool? Result = new CustomMessageBox("Incorrect date format!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }

            cd.CVV=txtCardCvv.Text.ToString();
            if (cd.CVV.Length != 3) {
                bool? Result = new CustomMessageBox("Incorrect CVV (3 characters)", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }
            cd.Card_Name=txtCardName.Text.ToString();
            if (cd.Card_Name.Length > 10) {
                bool? Result = new CustomMessageBox("Card name too long!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }
            cd.Card_Number=txtCardNumber.Text.ToString();
            if (cd.Card_Number.Length != 10) {
                bool? Result = new CustomMessageBox("Incorrect card number (10 characters)", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }
            context.Credit_Card.Add(cd);
            context.SaveChanges();
            Global_Rent.rt.ID_Credit_Card = cd.ID_Credit;
            context.Rents.Add(Global_Rent.rt);
            context.SaveChanges();
            Factura f = new Factura(Global_Client.cl.Username,DateTime.Now.ToString()," ",Global_Rent.rt.Total_Price);
            var res = (from c in context.Cars
                      where c.ID_Car == Global_Rent.rt.ID_Car
                      select c).First();
            f.DetaliiFacturare = f.MergeInfo(res.Brand.Name,res.Model.Name,Global_Rent.rt.PickUp_Date.ToString(),Global_Rent.rt.DropDown_Date.ToString(),true,txtCardNumber.Text.ToString());
            f.CreateDocument();
            MessageBoxMD w=new MessageBoxMD();
            this.Close();
            w.Show();
        }

      
    }
}
