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
    /// Interaction logic for ChoosePaymentMethodWindow.xaml
    /// </summary>
    public partial class ChoosePaymentMethodWindow : Window
    {
        public int car_ID { get; set; }
        public ChoosePaymentMethodWindow(int id )
        {
            car_ID = id;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            RentStep1 w = new RentStep1(car_ID);
            Close();
            w.ShowDialog();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (CardMethodCb.IsChecked == true)
            {
                CardWindow w = new CardWindow();
                Close();
                w.ShowDialog();
            }
            else
            {
                MessageBoxMD w = new MessageBoxMD();
                var context = new Car_RentEntities();
                context.Rents.Add(Global_Rent.rt);
                context.SaveChanges();
                this.Close();
                w.ShowDialog();
            }

        }
    }
}
