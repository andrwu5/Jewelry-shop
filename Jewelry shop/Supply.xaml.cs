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
    /// Логика взаимодействия для Supply.xaml
    /// </summary>
    public partial class Supply : Window
    {
        //private Connection.ConnectionSupply connectionSupply;
        //List<Connection.ConnectionSupply> Supplies;

        public string extension = string.Empty;
        private string QR = "";
        public Supply()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //Supplies = (new DBProcedure()).getSupplyList();
            //dgSupply.ItemsSource = Supplies;

        }

        private void dgFill(string qr)
        {
            ConnectionSupply connection = new ConnectionSupply();
            ConnectionSupply.qrSupply = qr;
            connection.Supply_Fill();
            dgSupply.ItemsSource = connection.dtSupply.DefaultView;
            dgSupply.Columns[0].Visibility = Visibility.Hidden;
        }
        DBProcedure procedures = new DBProcedure();
        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().insertSupply(new Connection.ConnectionSupply(
            //    -1,
            //    tbDate.Text,
            //    tbSapplyer.Text,
            //    Convert.ToInt32(tbAmmount.Text)
            //    ));
            //Supplies = (new DBProcedure()).getSupplyList();
            //dgSupply.ItemsSource = Supplies;
            procedures.insertSupply(tbDate.Text, tbSapplyer.Text, tbAmmount.Text);
            dgFill(QR);
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().updateSupply(new Connection.ConnectionSupply(
            //     this.connectionSupply.ID_Supply,
            //    tbDate.Text,
            //    tbSapplyer.Text,
            //    Convert.ToInt32(tbAmmount.Text)
            //    ));
            //Supplies = (new DBProcedure()).getSupplyList();
            //dgSupply.ItemsSource = Supplies;
            try
            {
                DataRowView ID = (DataRowView)dgSupply.SelectedItems[0];
                if (ID == null)
                    MessageBox.Show("", "");
                else
                    procedures.updateSupply(Convert.ToInt32(ID["ID_Sapply"]),tbDate.Text, tbSapplyer.Text, tbAmmount.Text);
                dgFill(QR);
            }
            catch
            {

            }
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Удалить выбранную запись?",
             "Удаление записи", MessageBoxButton.YesNo,
             MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    DataRowView ID =
                      (DataRowView)dgSupply.SelectedItems[0];
                    procedures.deleteSupply(
                       Convert.ToInt32(ID["ID_Supply"]));
                    dgFill(QR);
                    break;
            }
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgSupply.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text)
                {
                    dgSupply.SelectedItem = dataRow;
                }
            }
        }

        //private void BtFilter_Click(object sender, RoutedEventArgs e)
        //{
        //    string newQR = QR + " where [Date] like '%" + tbSearch.Text + "%' or " +
        //        "[Supplyer] like '%" + tbSearch.Text + "%' or " +
        //        "[Ammount] like '%" + tbSearch.Text + "%'";
        //    dgFill(QR);
        //}

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = ConnectionSupply.qrSupply;
            dgFill(QR);
        }
    }
}
