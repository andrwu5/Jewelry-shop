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
    /// Логика взаимодействия для Ogranka.xaml
    /// </summary>
    public partial class Ogranka : Window
    {
        public string extension = string.Empty;
        private string QR = "";
        public Ogranka()
        {
            InitializeComponent();
        }

        DBProcedure procedures = new DBProcedure();
        private void dgFill1(string qr)
        {
            ConnectionOgranka connection = new ConnectionOgranka();
            ConnectionOgranka.qrOgranka = qr;
            connection.Ogranka_Fill1();
            dgOgranka.ItemsSource = connection.dtOgranka.DefaultView;
            dgOgranka.Columns[0].Visibility = Visibility.Hidden;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = ConnectionOgranka.qrOgranka;
            dgFill1(QR);
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            var roleList = new DBProcedure().getRoleList(Session.currentUser.ID_Role);
            InitializeComponent();

            if (roleList.Count == 1)
            {
                var role = roleList[0];

                this.Title = role.Title_Role;

                if (role.Admin == 1)
                {
                    Spravochnik spravochnik = new Spravochnik();
                    spravochnik.Show();
                    Visibility = Visibility.Collapsed;
                }
                else
                {
                    Close();
                }
            }
        }

        private void btInsert_Ogranka_Click(object sender, RoutedEventArgs e)
        {
            procedures.insertOgranka(tbOgranka.Text, tbGem.Text, tbCarats.Text);
            dgFill1(QR);
        }

        private void btUpdate_Ogranka_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView ID = (DataRowView)dgOgranka.SelectedItems[0];
                if (ID == null)
                    MessageBox.Show("", "");
                else
                    procedures.updateOgranka(tbOgranka.Text, Convert.ToInt32(ID["ID_Ogranka"]), tbGem.Text, tbCarats.Text);
                dgFill1(QR);
            }
            catch
            {

            }
        }

        private void btDelete_Ogranka_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Удалить выбранную запись?",
              "Удаление записи", MessageBoxButton.YesNo,
              MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    DataRowView ID =
                      (DataRowView)dgOgranka.SelectedItems[0];
                    procedures.deleteOgranka(
                       Convert.ToInt32(ID["ID_Ogranka"]));
                    dgFill1(QR);
                    break;
            }
        
        }
    }
}
