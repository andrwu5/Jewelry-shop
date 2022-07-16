using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Diagnostics;
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
using System.Data.SqlClient;
using Jewelry_shop.Connection;
//using Xceed.Words.NET;
//using Xceed.Document.NET;
//using Word = Microsoft.Office.Interop.Word;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace Jewelry_shop
{
    /// <summary>
    /// Логика взаимодействия для Position.xaml
    /// </summary>
    public partial class Position : Window
    {
        public string extension = string.Empty;
        private string QR = "";
        public Position()
        {
            InitializeComponent();
        }

        DBProcedure procedures = new DBProcedure();
        private void dgFill2(string qr)
        {
            ConnectionPosition connection = new ConnectionPosition();
            ConnectionPosition.qrPosition = qr;
            connection.Position_Fill2();
            dgPosition.ItemsSource = connection.dtPosition.DefaultView;
            dgPosition.Columns[0].Visibility = Visibility.Hidden;
        }

        private void btInsert_Position_Click(object sender, RoutedEventArgs e)
        {
            procedures.insertPosition(tbJob_title.Text, tbSalary.Text);
            dgFill2(QR);
        }

        private void btUpdate_Position_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView ID = (DataRowView)dgPosition.SelectedItems[0];
                if (ID == null)
                    MessageBox.Show("", "");
                else
                    procedures.updatePosition(Convert.ToInt32(ID["ID_Position"]), tbJob_title.Text, tbSalary.Text);
                dgFill2(QR);
            }
            catch
            {

            }
        }

        private void btDelete_Position_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Удалить выбранную запись?",
             "Удаление записи", MessageBoxButton.YesNo,
             MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    DataRowView ID =
                      (DataRowView)dgPosition.SelectedItems[0];
                    procedures.deletePosition(
                       Convert.ToInt32(ID["ID_Position"]));
                    dgFill2(QR);
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = ConnectionPosition.qrPosition;
            dgFill2(QR);
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
