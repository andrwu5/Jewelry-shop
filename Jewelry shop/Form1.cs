using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Jewelry_shop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btChecked_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection sql
                = new System.Data.SqlClient.SqlConnection(
                string.Format("Data Source = {0}; Initial Catalog =" +
                " {1}; Integrated Security = true;", cbServers.Text,
                cbDatabases.Text));
            try
            {
                sql.Open();
                btConnect.Enabled = true;
            }
            catch
            {

            }
            finally
            {
                sql.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Вызов класса конфигурации
            Configuration_class configuration
                = new Configuration_class();
            //Присвоение event action события
            configuration.Server_Collection
                += Configuration_Server_Collection; ;
            //Обяхвление экземпляра потока
            Thread threadServers =
                new Thread(configuration.SQL_Server_Enumurator);
            //Запуск потока
            threadServers.Start();
        }
        private void Configuration_Server_Collection(DataTable obj)
        {
            //Вызов делегата для присвоения в него фрагмента кода
            //Через лямбда выражение => в делегат приваиватся код
            Action action = () =>
            {
                //Для каждой строки таблицы в выпадающий список 
                //Дополнить колекцию пунктов Server Name\Machine Name
                foreach (DataRow r in obj.Rows)
                {
                    cbServers.Items.Add(
                        string.Format(@"{0}\{1}", r[0], r[1]));
                }
                cbServers.Enabled = true;
                btChecked.Enabled = true;
            };
            //Присвоение фонового потока в основной
            Invoke(action);
        }

        private void cbServers_SelectedIndexChanged(object sender, EventArgs e)
        {

            Configuration_class configuration
                = new Configuration_class();
            configuration.ds = cbServers.SelectedItem.ToString();
            configuration.Conection_Checked
                += Configuration_Conection_Checked;
            Thread thread
                = new Thread(configuration.SQL_Data_Base_Checking);
            thread.Start();
        }

        private void Configuration_Conection_Checked(bool obj)
        {
            switch (obj)
            {
                //Если подключение выполнено верно то появляется сообщение
                case true:
                    MessageBox.Show("Проверка выполнена!");
                    Action action = () =>
                    {
                        //Повторение метода выбора
                        Configuration_class configuration_coll
                            = new Configuration_class();
                        configuration_coll.Data_Base_Collection
                            += Configuration_Data_Base_Collection;
                        Thread threadBases
                            = new Thread(configuration_coll.SQL_Data_Base_Collection);
                        threadBases.Start();
                        btConnect.Enabled = true;
                    };
                    Invoke(action);
                    break;
                case false:
                    //Вслучае если  нет подключения повторяем сбор данных
                    //о сервере
                    Configuration_class configuration
                        = new Configuration_class();
                    configuration.Server_Collection
                        += Configuration_Server_Collection;
                    Thread threadServers
                        = new Thread(configuration.SQL_Server_Enumurator);
                    threadServers.Start();
                    break;
            }
        }
        private void Configuration_Data_Base_Collection(DataTable obj)
        {
            Action action = () =>
            {
                cbDatabases.Items.Clear();
                foreach (DataRow r in obj.Rows)
                {
                    cbDatabases.Items.Add(r[0]);
                }
                cbDatabases.Enabled = true;
                btChecked.Enabled = true;
            };
            Invoke(action);
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            switch (cbDatabases.Text == "")
            {
                case true:
                    //В случае если поле не заполнено
                    MessageBox.Show("Не выбрана нужная база данных!",
                        "Ювелирный магазин не выбран",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbDatabases.Focus();
                    break;
                case false:
                    Configuration_class configuration
                        = new Configuration_class();
                    //Присвоение конфигурации в реестр ОС
                    configuration.SQL_Server_Configuration_Set(
                        cbServers.Text, cbDatabases.Text);
                    //Присвоение в переменную значение 
                    //о правильности подключения
                    Program.connect = true;
                    //Перезапуск программы
                    Application.Restart();
                    break;
            }
        }
    }
}
