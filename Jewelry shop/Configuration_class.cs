using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop
{
    class Configuration_class
    {
        public static string Empty = "Empty";
        public event Action<DataTable> Server_Collection;
        //Получает колекцию доступных серверов
        public event Action<DataTable> Data_Base_Collection;
        //Получает колекцию доступных БД на сервере
        public event Action<bool> Conection_Checked;
        //Определяет статус подключения
        public string DS = Empty,// Переменная Data Source
            IC = Empty;//Переменная Initial Catalog
        public string ds = "";//Проверка подключения Data Source
        public static SqlConnection connection = new SqlConnection();
        /// <summary>
        /// Ментод получения информации о строке подключения к БД
        /// свойств Data Source и Initial Catalog технологии долступа 
        /// к данным ADO.Net
        /// </summary>
        /// 
        public bool isConnection
        {
            get
            {
                return DS != Empty && IC != Empty;
            }
        }
        public void SQL_Server_Configuration_Get()
        {
            //Создаёт каталог в одном из корней реестра ОС
            RegistryKey registry = Registry.CurrentUser;
            //Создаёт папку в выбраном коревом каталоге рееста ОС
            RegistryKey key = registry.CreateSubKey("Server_Configuration");
            try
            {
                //Пытаюсь получить значения из переменных в реестре
                DS = key.GetValue("DS").ToString();
                IC = key.GetValue("IC").ToString();
            }
            catch
            {
                DS = Empty;
                IC = Empty;
            }
            finally
            {
                //Обновление строки подкючения
                connection.ConnectionString = "Data Source = " + DS +
                    "; Initial Catalog = " + IC +
                    "; Integrated Security = true;";
            }
        }
        /// <summary>
        /// Метод обновления информации о подкелючении к источнику данных
        /// по технологии ADO.Net
        /// </summary>
        /// <param name="ds">Запись значения Data Source</param>
        /// <param name="ic">Запись значения Initial Catalog</param>
        public void SQL_Server_Configuration_Set(string ds, string ic)
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Server_Configuration");
            key.SetValue("DS", ds);//Запись значения в переменную реестра
            key.SetValue("IC", ic);
            SQL_Server_Configuration_Get();
        }
        /// <summary>
        /// Метод возвращает список доступных серверов в локаьном окружении
        /// </summary>
        public void SQL_Server_Enumurator()
        {
            //Полдучет сведения о доступных серверах
            SqlDataSourceEnumerator sourceEnumerator
                = SqlDataSourceEnumerator.Instance;
            //Присвоение Event Action списка серверов ввиде таблицы
            Server_Collection(sourceEnumerator.GetDataSources());
        }
        /// <summary>
        /// Метод проверки подключения к источнику данных
        /// </summary>
        public void SQL_Data_Base_Checking()
        {
            connection.ConnectionString = "Data Source = " + ds + "; " +
                "Initial Catalog = master; Integrated Security = True";
            try
            {
                //Если подключение по источнеику данных открыть можно
                // в Event Action присваиваю true
                connection.Open();
                Conection_Checked(true);
            }
            catch
            //В противном случае false
            {
                Conection_Checked(false);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Метод получает список доступных на сервере 
        /// баз данных по технологии доступа к данным ADO.Net
        /// </summary>
        public void SQL_Data_Base_Collection()
        {
            //Запрос на выборку названия баз данных с конкретного сервера
            //где база не назвается master, model, tempdb, msdb
            //и имеет схожее название с Sale_Data_Base
            SqlCommand command = new SqlCommand("select name from sys.databases " +
                "where name not in ('master','tempdb','model','msdb') " +
                "and name like 'Jewelry_shop'", connection);

            try
            {
                connection.Open();
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                Data_Base_Collection(table);
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
        }
    }
}
