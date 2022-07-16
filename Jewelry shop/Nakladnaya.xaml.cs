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
    /// Логика взаимодействия для Nakladnaya.xaml
    /// </summary>
    public partial class Nakladnaya : Window
    {
        //private Connection.ConnectionNakladnaya connectionNakladnaya;
        //List<Connection.ConnectionNakladnaya> Nakladnayaes;
        //List<Connection.ConnectionSupply> Supply;
        List<Connection.ConnectionSupplyDetail> SupplyDetail;
        //List<Connection.ConnectionNakladnayaDetail> NakladnayaDetail;

        public string extension = string.Empty;
        private string QR = "";
        public Nakladnaya()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //NakladnayaDetail = (new DBProcedure()).getNakladnayaDetailList();
            //dgNakladnaya.ItemsSource = NakladnayaDetail;
            //SupplyDetail = (new DBProcedure()).getSupplyDetailList();
            //lbSupply.ItemsSource = SupplyDetail;
            //lbSupply.SelectedValuePath = "ID_Supply";
            //lbSupply.DisplayMemberPath = "SupplyInfo";
        }

        DBProcedure procedures = new DBProcedure();

        private void dgFill(string qr)
        {
            ConnectionNakladnaya connection = new ConnectionNakladnaya();
            ConnectionNakladnaya.qrNakladnaya = qr;
            connection.Nakladnaya_Fill();
            dgNakladnaya.ItemsSource = connection.dtNakladnaya.DefaultView;
            dgNakladnaya.Columns[0].Visibility = Visibility.Hidden;
            dgNakladnaya.Columns[2].Visibility = Visibility.Hidden;
            dgNakladnaya.Columns[3].Visibility = Visibility.Hidden;
        }

        private void lbFill()
        {
            ConnectionSupply connection = new ConnectionSupply();
            connection.Supply_Fill();
            lbSupply.ItemsSource
             = connection.dtSupply.DefaultView;
            lbSupply.SelectedValuePath = "ID_Supply";
            lbSupply.DisplayMemberPath = "Информация о поставке";
        }

        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().insertNakladnaya(new Connection.ConnectionNakladnaya(
            //    -1,
            //    Convert.ToInt32(tbNumberNakladnaya.Text),
            //    Convert.ToInt32(lbSupply.SelectedValue)
            //    ));
            //Nakladnayaes = (new DBProcedure()).getNakladnayaList();
            //dgNakladnaya.ItemsSource = Nakladnayaes;
            procedures.insertNakladnaya(tbNumberNakladnaya.Text, Convert.ToInt32(lbSupply.SelectedValue));
            dgFill(QR);
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().updateNakladnaya(new Connection.ConnectionNakladnaya(
            //    this.connectionNakladnaya.ID_Nakladnaya,
            //    Convert.ToInt32(tbNumberNakladnaya.Text),
            //    Convert.ToInt32(lbSupply.SelectedValue)
            //    ));
            //Nakladnayaes = (new DBProcedure()).getNakladnayaList();
            //dgNakladnaya.ItemsSource = Nakladnayaes;
            try
            {
                DataRowView ID = (DataRowView)dgNakladnaya.SelectedItems[0];
                if (ID == null)
                    MessageBox.Show("", "");
                else
                    procedures.updateNakladnaya(tbNumberNakladnaya.Text, Convert.ToInt32(ID["ID_Nakladnaya"]), Convert.ToInt32(lbSupply.SelectedValue));
                dgFill(QR);
            }
            catch
            {

            }
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            //int selectedIndex = dgNakladnaya.SelectedIndex;
            //new DBProcedure().deleteNakladnaya(Nakladnayaes[selectedIndex].ID_Nakladnaya);
            //MessageBox.Show("Операция выполнена");
            //Nakladnayaes = (new DBProcedure()).getNakladnayaList();
            //dgNakladnaya.ItemsSource = Nakladnayaes;
            switch (MessageBox.Show("Удалить выбранную запись?",
             "Удаление записи", MessageBoxButton.YesNo,
             MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    DataRowView ID =
                      (DataRowView)dgNakladnaya.SelectedItems[0];
                    procedures.deleteNakladnaya(
                       Convert.ToInt32(ID["ID_Nakladnaya"]));
                    dgFill(QR);
                    break;
            }
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgNakladnaya.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text) 
                {
                    dgNakladnaya.SelectedItem = dataRow;
                }
            }
        }

        //private void BtFilter_Click(object sender, RoutedEventArgs e)
        //{
        //    string newQR = QR + " where [Number] like '%" + tbSearch.Text + "%' or " +
        //        "[Supply_ID] like '%" + tbSearch.Text + "%'";
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
            QR = ConnectionNakladnaya.qrNakladnaya;
            dgFill(QR);
            lbFill();
        }
    }
}
