using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Jewelry_shop.Connection
{
    public class ConnectionPosition
    {
        public static SqlConnection connection = new SqlConnection(
                "Data Source = DESKTOP-5S0UIB4\\MYSERVER; " +
                " Initial Catalog=Jewelry_shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                " User ID = SA; Password = \"timtim\"");

        public DataTable dtPosition = new DataTable("Position");

        public static string qrPosition = "SELECT[ID_Position],[Job_title]+' '+[Salary] as \"Информация о должности\" FROM [dbo].[Position]";
        
        private SqlCommand command = new SqlCommand("", connection);
        private void dtFil2(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Position_Fill2()
        {
            dtFil2(dtPosition, qrPosition);
        }
    }
}
