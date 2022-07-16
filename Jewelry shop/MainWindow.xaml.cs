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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            InitializeComponent();
            Session.mainWindow = this;
        }

        private void btAdress_Click(object sender, RoutedEventArgs e)
        {
            Adress adress = new Adress();
            adress.Show();
            Visibility = Visibility.Collapsed;
        }

        private void btGuarantee_Click(object sender, RoutedEventArgs e)
        {
            Guarantee guarantee = new Guarantee();
            guarantee.Show();
            Visibility = Visibility.Collapsed;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Visibility = Visibility.Collapsed;
        }

        private void btVacancies_Click(object sender, RoutedEventArgs e)
        {
            Vacancies vacancies = new Vacancies();
            vacancies.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LaunchWindow launchWindow = new LaunchWindow();
            launchWindow.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            KotalogJewelry kotalogJewelry = new KotalogJewelry();
            kotalogJewelry.Show();
            Visibility = Visibility.Collapsed;

        }

       
    }
}
