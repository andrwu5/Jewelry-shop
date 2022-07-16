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

namespace Jewelry_shop
{
    /// <summary>
    /// Логика взаимодействия для Spravochnik.xaml
    /// </summary>
    public partial class Spravochnik : Window
    {
        public Spravochnik()
        {
            InitializeComponent();
        }

        private void btJewelry_Click(object sender, RoutedEventArgs e)
        {
            Jewelry jewelry = new Jewelry();
            jewelry.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtKlients_Click(object sender, RoutedEventArgs e)
        {
            Klients klients = new Klients();
            klients.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtEmployee_Click(object sender, RoutedEventArgs e)
        {
            ListEmployee listEmployee = new ListEmployee();
            listEmployee.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtSupply_Click(object sender, RoutedEventArgs e)
        {
            Supply supply = new Supply();
            supply.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtNakladnaya_Click(object sender, RoutedEventArgs e)
        {
            Nakladnaya nakladnaya = new Nakladnaya();
            nakladnaya.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ogranka ogranka = new Ogranka();
            ogranka.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Position position = new Position();
            position.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
                    Spravochnik spravochnik = new Spravochnik();
                    spravochnik.Show();
                    Visibility = Visibility.Collapsed;
               
        }
    }
}
