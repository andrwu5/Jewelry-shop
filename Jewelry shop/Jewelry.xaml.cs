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
using Xceed.Words.NET;
using Xceed.Document.NET;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace Jewelry_shop
{
    /// <summary>
    /// Логика взаимодействия для Jewelry.xaml
    /// </summary>
    public partial class Jewelry : Window
    {
        //private Connection.ConnectionJewelry connectionJewelry;
        //private Connection.ConnectionOgranka connectionOgranka;
        //private Connection.ConnectionQuality connectionQuality;
        //List<Connection.ConnectionJewelry> Jewelrys;
        //List<Connection.ConnectionJewelryDetail> JewelryDetail;
        //List<Connection.ConnectionOgranka> Ogranka;
        //List<Connection.ConnectionOgrankaDetail> OgrankaDetail;
        //List<Connection.ConnectionQuality> Quality;

        public string extension = string.Empty;
        private string QR = "";
        public Jewelry()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //JewelryDetail = (new DBProcedure()).getJewelryDetailList();
            //dgJewelry.ItemsSource = JewelryDetail;
            //OgrankaDetail = (new DBProcedure()).getOgrankaDetailList();
            //lbOgranka.ItemsSource = OgrankaDetail;
            //lbOgranka.SelectedValuePath = "ID_Ogranka";
            //lbOgranka.DisplayMemberPath = "OgrankaInfo";
            //Quality = (new DBProcedure()).getQualityList();
            //lbQuality.ItemsSource = Quality;
            //lbQuality.SelectedValuePath = "ID_Quality";
            //lbQuality.DisplayMemberPath = "Material";
           // updateData();
        }

        //public void updateData()
        //{
        //    JewelryDetail = (new DBProcedure()).getJewelryDetailList();
        //    dgJewelry.ItemsSource = JewelryDetail;
        //    dgJewelry.Columns[0].Visibility = Visibility.Hidden;
        //    dgJewelry.Columns[4].Visibility = Visibility.Hidden;
        //    dgJewelry.Columns[5].Visibility = Visibility.Hidden;
        //    dgJewelry.Columns[9].Visibility = Visibility.Hidden;
        //    dgJewelry.Columns[10].Visibility = Visibility.Hidden;

        //    //dataGridCars.Columns[4].Header = "Статус";
        //}
        DBProcedure procedures = new DBProcedure();

        private void dgFill(string qr)
        {
            ConnectionJewelry connection = new ConnectionJewelry();
            ConnectionJewelry.qrJewelry = qr;
            connection.Jewelry_Fill();
            dgJewelry.ItemsSource = connection.dtJewelry.DefaultView;
            dgJewelry.Columns[0].Visibility = Visibility.Collapsed;
            dgJewelry.Columns[4].Visibility = Visibility.Collapsed;
            dgJewelry.Columns[5].Visibility = Visibility.Collapsed;
            dgJewelry.Columns[9].Visibility = Visibility.Collapsed;
            dgJewelry.Columns[10].Visibility = Visibility.Collapsed;
        }

        private void lbFill1()
        {
            ConnectionOgranka connection = new ConnectionOgranka();
            connection.Ogranka_Fill1();
           lbOgranka.ItemsSource
            = connection.dtOgranka.DefaultView;
            lbOgranka.SelectedValuePath = "ID_Ogranka";
            lbOgranka.DisplayMemberPath = "Информация об огранке";


        }

        private void lbFill2()
        {
            ConnectionQuality connection = new ConnectionQuality();
            connection.Quality_Fill2();
            lbQuality.ItemsSource
             = connection.dtQuality.DefaultView;
            lbQuality.SelectedValuePath = "ID_Quality";
            lbQuality.DisplayMemberPath = "Материал";

        }
        private void btInsert_Jewelry_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().insertJewelry(new Connection.ConnectionJewelry(
            //                -1,
            //                tbNameJewelry.Text,
            //                Convert.ToInt32(tbAmmount.Text),
            //                tbCost.Text,
            //                Convert.ToInt32(lbOgranka.SelectedValue),
            //                Convert.ToInt32(lbQuality.SelectedValue)
            //                ));
            //Jewelrys = (new DBProcedure()).getJewelryList();
            //dgJewelry.ItemsSource = Jewelrys;
            procedures.insertJewelry(tbNameJewelry.Text, Convert.ToInt32(tbAmmount.Text), tbCost.Text, Convert.ToInt32(lbOgranka.SelectedValue), Convert.ToInt32(lbQuality.SelectedValue));
            dgFill(QR);
        }

        private void btUpdate_Jewelry_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().updateJewelry(new Connection.ConnectionJewelry(
            //                this.connectionJewelry.ID_Jewelry,
            //                tbNameJewelry.Text,
            //                Convert.ToInt32(tbAmmount.Text),
            //                tbCost.Text,
            //                Convert.ToInt32(lbOgranka.SelectedValue),
            //                Convert.ToInt32(lbQuality.SelectedValue)
            //                ));
            //Jewelrys = (new DBProcedure()).getJewelryList();
            //dgJewelry.ItemsSource = Jewelrys;

            try
            {
                DataRowView ID = (DataRowView)dgJewelry.SelectedItems[0];
                if (ID == null)
                    MessageBox.Show("", "");
                else
                    procedures.updateJewelry(tbNameJewelry.Text, Convert.ToInt32(ID["ID_Jewelry"]), Convert.ToInt32(tbAmmount.Text), tbCost.Text, Convert.ToInt32(lbOgranka.SelectedValue), Convert.ToInt32(lbQuality.SelectedValue));
                dgFill(QR);
            }
            catch
            {

            }
        }

        private void btDelete_Jewelry_Click(object sender, RoutedEventArgs e)
        {
            //int selectedIndex = dgJewelry.SelectedIndex;
            //new DBProcedure().deleteJewelry(Jewelrys[selectedIndex].ID_Jewelry);
            //MessageBox.Show("Операция выполнена");
            //Jewelrys = (new DBProcedure()).getJewelryList();
            //dgJewelry.ItemsSource = Jewelrys;

            switch (MessageBox.Show("Удалить выбранную запись?",
              "Удаление записи", MessageBoxButton.YesNo,
              MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    DataRowView ID =
                      (DataRowView)dgJewelry.SelectedItems[0];
                    procedures.deleteJewelry(
                       Convert.ToInt32(ID["ID_Jewelry"]));
                    dgFill(QR);
                    break;
            }
        }

        //private void btInsert_Ogranka_Click(object sender, RoutedEventArgs e)
        //{
        //    //if (tbOgranka.Text == string.Empty) ;
        //    //(tbGem.Text == string.Empty);
        //    //(tbCarats.Text == string.Empty)
        //    //{
        //    //    MessageBox.Show("Ошибка");
        //    //    return;
        //    //}
        //    //new DBProcedure().insertOgranka(new Connection.ConnectionOgranka(
        //    //                -1,
        //    //                tbOgranka.Text,
        //    //                tbGem.Text,
        //    //                tbCarats.Text
        //    //                ));
        //    //OgrankaDetail = (new DBProcedure()).getOgrankaDetailList();
        //    //lbOgranka.ItemsSource = OgrankaDetail;
        //    //lbOgranka.SelectedValuePath = "ID_Ogranka";
        //    //lbOgranka.DisplayMemberPath = "OgrankaInfo";
        //    procedures.insertOgranka(tbOgranka.Text, tbGem.Text, tbCarats.Text);
        //    lbFill1();
        //}

        //private void btUpdate_Ogranka_Click(object sender, RoutedEventArgs e)
        //{
        //    //new DBProcedure().updateOgranka(new Connection.ConnectionOgranka(
        //    //               this.connectionOgranka.ID_Ogranka,
        //    //                tbOgranka.Text,
        //    //                tbGem.Text,
        //    //                tbCarats.Text
        //    //                ));
        //    //OgrankaDetail = (new DBProcedure()).getOgrankaDetailList();
        //    //lbOgranka.ItemsSource = OgrankaDetail;
        //    //lbOgranka.SelectedValuePath = "ID_Ogranka";
        //    //lbOgranka.DisplayMemberPath = "OgrankaInfo";
        //    try
        //    {
        //        DataRowView ID = (DataRowView)lbOgranka.SelectedItems[0];
        //        if (ID == null)
        //            MessageBox.Show("", "");
        //        else
        //            procedures.updateOgranka(tbOgranka.Text, Convert.ToInt32(ID["ID_Ogranka"]), tbGem.Text, tbCarats.Text);
        //        lbFill1();
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void btDelete_Ogranka_Click(object sender, RoutedEventArgs e)
        //{
        //    //int selectedIndex = lbOgranka.SelectedIndex;
        //    //new DBProcedure().deleteOgranka(Ogranka[selectedIndex].ID_Ogranka);
        //    //MessageBox.Show("Операция выполнена");
        //    //OgrankaDetail = (new DBProcedure()).getOgrankaDetailList();
        //    //lbOgranka.ItemsSource = OgrankaDetail;
        //    //lbOgranka.SelectedValuePath = "ID_Ogranka";
        //    //lbOgranka.DisplayMemberPath = "OgrankaInfo";
        //    switch (MessageBox.Show("Удалить выбранную запись?",
        //     "Удаление записи", MessageBoxButton.YesNo,
        //     MessageBoxImage.Warning))
        //    {
        //        case MessageBoxResult.Yes:
        //            DataRowView ID =
        //              (DataRowView)lbOgranka.SelectedItems[0];
        //            procedures.deleteJewelry(
        //               Convert.ToInt32(ID["ID_Jewelry"]));
        //            dgFill(QR);
        //            break;
        //    }
        //}

        private void btInsert_Quality_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().insertQuality(new Connection.ConnectionQuality(
            //                -1,
            //                tbQuality.Text
            //                ));
            //Quality = (new DBProcedure()).getQualityList();
            //lbQuality.ItemsSource = Quality;
            //lbOgranka.SelectedValuePath = "ID_Quality";
            //lbOgranka.DisplayMemberPath = "Material";
            procedures.insertQuality(tbQuality.Text);
            lbFill2();
        }

        private void btUpdate_Quality_Click(object sender, RoutedEventArgs e)
        {
            //    new DBProcedure().updateQuality(new Connection.ConnectionQuality(
            //                    this.connectionQuality.ID_Quality,
            //                    tbQuality.Text
            //                    ));
            //    Quality = (new DBProcedure()).getQualityList();
            //    lbQuality.ItemsSource = Quality;
            try
            {
                DataRowView ID = (DataRowView)lbOgranka.SelectedItems[0];
                if (ID == null)
                    MessageBox.Show("", "");
                else
                    procedures.updateQuality(tbQuality.Text, Convert.ToInt32(ID["ID_Quality"]));
                lbFill2();
            }
            catch
            {

            }

        }


        private void btDelete_Quality_Click(object sender, RoutedEventArgs e)
        {
            //int selectedIndex = lbQuality.SelectedIndex;
            //new DBProcedure().deleteQuality(Quality[selectedIndex].ID_Quality);
            //MessageBox.Show("Операция выполнена");
            //Quality = (new DBProcedure()).getQualityList();
            //lbQuality.ItemsSource = Quality;

            switch (MessageBox.Show("Удалить выбранную запись?",
            "Удаление записи", MessageBoxButton.YesNo,
             MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    DataRowView ID =
                      (DataRowView)lbQuality.SelectedItems[0];
                    procedures.deleteQuality(
                       Convert.ToInt32(ID["ID_Quality"]));
                    lbFill2();
                    break;
            }
        }

        

        //private void btFilter_Click(object sender, RoutedEventArgs e)
        //{
        //    string newQR = QR + " where [Name_Jewelry] like '%" + tbSearch.Text + "%' or " +
        //       "[Ammount] like '%" + tbSearch.Text + "%' or " +
        //       "[Cost]+' '+[OgrankaInfo]+' '+[Material] like '%" + tbSearch.Text + "%'";
        //    //"[OgrankaInfo] like '%" + tbSearch.Text + "%'or " +
        //    //   "[Material] like '%" + tbSearch.Text + "%'";
        //    dgFill(QR);
        //}

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgJewelry.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                   dataRow.Row.ItemArray[5].ToString() == tbSearch.Text)
                {
                    dgJewelry.SelectedItem = dataRow;
                }
            }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = ConnectionJewelry.qrJewelry;
            dgFill(QR);
            lbFill1();
            lbFill2();
        }


    }
}
