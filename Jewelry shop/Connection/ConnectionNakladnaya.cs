using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Jewelry_shop.Connection
{
    public class ConnectionNakladnaya
    {

        public static SqlConnection connection = new SqlConnection(
                  "Data Source = DESKTOP-5S0UIB4\\MYSERVER; " +
                  " Initial Catalog=Jewelry_shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                  " User ID = SA; Password = \"timtim\"");

        public DataTable dtNakladnaya = new DataTable("Nakladnaya");

        public static string qrNakladnaya = "SELECT[ID_Nakladnaya]," +
            "[Number] as \"Номер накладной\",[Supply_ID],[ID_Supply],[Date] as \"Дата поставки\",[Supplyer] as \"Поставщик\",[Ammount_Accepted_Jewelry] as \"Кол-во принятых украшений\"FROM" +
            "[dbo].[Nakladnaya] INNER JOIN [dbo].[Supply]" +
            " ON [dbo].[Nakladnaya].[Supply_ID]" +
            " =[dbo].[Supply].[ID_Supply]";

        //public int ID_Nakladnaya { get; set; }
        //public int Number { get; set; }
        //public int Supply_ID { get; set; }
        //public ConnectionNakladnaya(int iD_Nakladnaya, int number, int supply_ID)
        //{
        //    ID_Nakladnaya = iD_Nakladnaya;
        //    Number = number;
        //    Supply_ID = supply_ID;
        //}
        private SqlCommand command = new SqlCommand("", connection);
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Nakladnaya_Fill()
        {
            dtFill(dtNakladnaya, qrNakladnaya);
        }
    }
}
