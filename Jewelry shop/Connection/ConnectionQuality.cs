using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Jewelry_shop.Connection
{
    public class ConnectionQuality
    {
        public static SqlConnection connection = new SqlConnection(
                 "Data Source = DESKTOP-5S0UIB4\\MYSERVER; " +
                 " Initial Catalog=Jewelry_shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                 " User ID = SA; Password = \"timtim\"");

        public DataTable dtQuality = new DataTable("Quality");
        public static string qrQuality = "SELECT[ID_Quality]," +
            "[Material] as \"Материал\" FROM [dbo].[Quality]";
        //public int ID_Quality { get; set; }
        //public string Material { get; set; }
        //public ConnectionQuality(int iD_Quality, string material)
        //{
        //    ID_Quality = iD_Quality;
        //    Material = material;
        //}
        private SqlCommand command = new SqlCommand("", connection);
        private void dtFill2(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Quality_Fill2()
        {
            dtFill2(dtQuality, qrQuality);
        }
    }
}
