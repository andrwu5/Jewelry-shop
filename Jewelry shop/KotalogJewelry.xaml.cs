using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Words.NET;
using Xceed.Document.NET;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;


namespace Jewelry_shop
{
    /// <summary>
    /// Логика взаимодействия для KotalogJewelry.xaml
    /// </summary>
    public partial class KotalogJewelry : Window
    {
        List<Connection.ConnectionJewelrys> ListJewelrys;
        private Connection.ConnectionJewelrys connectionJewelry;


        public string extension = string.Empty;
        private string QR = "";

        int purshace_item = 0;
        int[] count = new int[9999]; int step = 0;
        int[] pushcar = new int[9999];
        string korz;
        public KotalogJewelry()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            count[step] = 1;
            step++;
            MessageBox.Show("Товар добавлен в корзину!");
            purshace_item++;
            Car.Header = "Корзина(" + purshace_item.ToString() + ")";
            pushcar[1]++;
            count[step++] = 0;
            tbKorz.Text = tbKorz.Text.ToString() + "     " + tbNameJewelry.Text.ToString() + "                                         " + tbAmmount.Text.ToString() + "                                                      " + tbCost.Text.ToString() + Environment.NewLine;
            Double db1, db2, db3, result, result2;
            db1 = Double.Parse(tbCost.Text);
            db2 = Double.Parse(tbAmmount.Text);
            db3 = Double.Parse(tbSumm.Text);
            result = db1 * db2;
            result2 = db3 + result;
            tbSumm.Text = Convert.ToString(result2);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListJewelrys = (new DBProcedure()).getJewelrysList();
            dgJewelry.ItemsSource = ListJewelrys;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dgJewelry.SelectedIndex;
            var ap = new DBProcedure().getJewelrysList();
            foreach (var it in ap)
            {
                if (it.ID_Jewelry == ListJewelrys[selectedIndex].ID_Jewelry) ;
                {
                    connectionJewelry = it;
                    break;
                }
            }
            switch ((Convert.ToInt32(tbAmmount.Text)) >= connectionJewelry.Ammount)
            {
                case (true):
                    MessageBox.Show("Столько товара нет на складе");
                    break;
                case (false):
                    lbAmmount.Visibility = Visibility.Visible;
                    tbAmmount.Visibility = Visibility.Visible;
                    int a = 1;
                    int b = Convert.ToInt32(tbAmmount.Text);
                    int result = a + b;
                    tbAmmount.Text = Convert.ToString(result);
                    break;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            switch ((Convert.ToInt32(tbAmmount.Text)) <= 1)
            {
                case (true):
                    MessageBox.Show("Значение не может быть меньше 1");
                    break;
                case (false):
                    lbAmmount.Visibility = Visibility.Visible;
                    tbAmmount.Visibility = Visibility.Visible;
                    int a = 1;
                    int p = Convert.ToInt32(tbAmmount.Text);
                    tbAmmount.Text = Convert.ToString(p - a);
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
            Visibility = Visibility.Collapsed;
        }

       
    }
}
