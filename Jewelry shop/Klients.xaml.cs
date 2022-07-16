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
using Xceed.Words.NET;
using Xceed.Document.NET;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace Jewelry_shop
{
    /// <summary>
    /// Логика взаимодействия для Klients.xaml
    /// </summary>
    public partial class Klients : Window
    {
       
        List<Connection.ConnectionKlientDetail> listKlient;

        public string extension = string.Empty;
        private string QR = "";
        public Klients()
        {
            InitializeComponent();
           // updateData();
        }
        private void updateData()
        {
            listKlient = (new DBProcedure()).getKlientDetailList();
            dgKlientSpravichnic.ItemsSource = listKlient;
           // dgKlientSpravichnic.Columns[0].Visibility = Visibility.Hidden;
           // dgKlientSpravichnic.Columns[1].Header = "Информация о клиенте";
        }
        private void Window_Activated(object sender, EventArgs e)
        {
           
            updateData();
            dgKlientSpravichnic.Columns[0].Visibility = Visibility.Collapsed;

        }

        private void createExportDoc()
        {
            try
            {


                DBProcedure con = new DBProcedure();

                var connectionKlientDetail = con.getKlientDetailList();

                if (extension == string.Empty)
                {
                    MessageBox.Show("Не выбран тип экспортруемого файла");
                    return;
                }

                switch (extension)
                {
                    case (".docx"):
                        string pathDocumentDOCX = Session.baseDir + "Список клиентов" + extension;
                        DocX document = DocX.Create(pathDocumentDOCX);
                        Xceed.Document.NET.Paragraph paragraph = document.InsertParagraph();
                        paragraph.
                            AppendLine("Документ '" + "Отчет список клиентов" + "' создан " + DateTime.Now.ToShortDateString()).
                            Font("Time New Roman").
                            FontSize(16).Bold().Alignment = Alignment.left;

                        paragraph.AppendLine();
                        Xceed.Document.NET.Table doctable = document.AddTable(connectionKlientDetail.Count + 1, 2);
                        doctable.Design = TableDesign.TableGrid;
                        doctable.TableCaption = "Список клиентов";

                        doctable.Rows[0].Cells[0].Paragraphs[0].Append("Список клиентов").Font("Times New Roman").FontSize(14);

                        for (int i = 0; i < connectionKlientDetail.Count; i++)
                        {
                            doctable.Rows[i + 1].Cells[0].Paragraphs[0].Append(connectionKlientDetail[i].KlientInfo).Font("Times New Roman").FontSize(14);
                        }
                        document.InsertParagraph().InsertTableAfterSelf(doctable);
                        document.Save();
                        MessageBox.Show("Отчет успешно сформирован!");
                        Process.Start(pathDocumentDOCX);
                        break;

                    case (".xlsx"):
                        Excel.Application excel;
                        Excel.Workbook worKbooK;
                        Excel.Worksheet worKsheeT;
                        Excel.Range celLrangE;

                        string pathDocumentXLSX = Session.baseDir + "Список клиентов" + extension;

                        try
                        {
                            excel = new Excel.Application();
                            excel.Visible = false;
                            excel.DisplayAlerts = false;
                            worKbooK = excel.Workbooks.Add(Type.Missing);


                            worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
                            worKsheeT.Name = "Список клиентов";

                            worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[1, 8]].Merge();
                            worKsheeT.Cells[1, 1] = "Список клиентов";
                            worKsheeT.Cells.Font.Size = 15;

                            for (int i = 0; i < connectionKlientDetail.Count; i++)
                            {
                                worKsheeT.Cells[i + 3, 1] = connectionKlientDetail[i].KlientInfo;
                            }

                            worKbooK.SaveAs(pathDocumentXLSX); ;
                            worKbooK.Close();
                            excel.Quit();
                            MessageBox.Show("Отчет успешно сформирован!");
                            Process.Start(pathDocumentXLSX);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                        finally
                        {
                            worKsheeT = null;
                            celLrangE = null;
                            worKbooK = null;
                        }

                        break;


                    case (".pdf"):
                        string pathDocumentPDF = Session.baseDir + "Список клиентов" + extension;
                        if (File.Exists(Session.baseDir + "Список клиентов.docx"))
                        {
                            Word.Application appWord = new Word.Application();
                            var wordDocument = appWord.Documents.Open(Session.baseDir + "Список клиентов.docx");
                            wordDocument.ExportAsFixedFormat(pathDocumentPDF, Word.WdExportFormat.wdExportFormatPDF);
                            MessageBox.Show("Отчет успешно сформирован!");
                            wordDocument.Close();
                            Process.Start(pathDocumentPDF);
                        }
                        else
                            MessageBox.Show("Сначала сформируйте отчет .docx");
                        break;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Отсутсвие Ms Office на компьютере. Пожалуйста скачайте его.");
                Process.Start("https://www.microsoft.com/ru-ru/microsoft-365/compare-all-microsoft-365-products?tab=1&rtc=1");
            }
        }

        DBProcedure procedure = new DBProcedure();
       

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().updateKlient(new Connection.ConnectionKlient(
            //    this.connectionKlientDetail.ID_Authorization,
            //    tbFirst_Name_Klient.Text,
            //    tbName_Klient.Text,
            //    tbMiddle_Name_Klient.Text,
            //    tbPhone_Number.Text
            //    ));
            //listKlient = (new DBProcedure()).getKlientDetailList();
            //dgKlientSpravichnic.ItemsSource = listKlient;
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    switch (MessageBox.Show("Удалить выбранную запись?",
            //   "Удаление записи", MessageBoxButton.YesNo,
            //    MessageBoxImage.Warning))
            //    {
            //        case MessageBoxResult.Yes:
            //            DataRowView ID =
            //              (DataRowView)dgKlientSpravichnic.SelectedItems[0];
            //            procedure.deleteKlient(
            //               Convert.ToInt32(ID["ID_Authorization"]));
            //            listKlient = (new DBProcedure()).getKlientList();
            //            dgKlientSpravichnic.ItemsSource = listKlient;
            //            break;
            //    }
            //}
            //catch
            //{

            //}
        }

        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            //string newQR = QR + " where [First_Name_Klient] like '%" + tbSearch.Text + "%' or " +
            //    "[Name_Klient] like '%" + tbSearch.Text + "%' or " +
            //    "[Middle_Name_Klient] like '%" + tbSearch.Text + "%'or " +
            //    "[Phone_Number] like '%" + tbSearch.Text + "%'";
            //listKlient = (new DBProcedure()).getKlientList();
            //    dgKlientSpravichnic.ItemsSource = listKlient;
        }

       

        private void dgKlientSpravichnic_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(createExportDoc));
            t.Start();
        }

        private void ComboBoxExport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)comboBoxExport.SelectedItem;
            extension = typeItem.Content.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        
    }
}
