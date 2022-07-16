using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Jewelry_shop.Connection
{
    public class ConnectionStatus_Employee
    {
        public static SqlConnection connection = new SqlConnection(
                "Data Source = DESKTOP-5S0UIB4\\MYSERVER; " +
                " Initial Catalog=Jewelry_shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                " User ID = SA; Password = \"timtim\"");

        public DataTable dtStatus_Employee = new DataTable("Status_Employee");
        public static string qrStatus_Employee = "SELECT[ID_Status_Employee]," +
            "[Name_Of_Employee_Status] as \"Статус\" FROM [dbo].[Status_Employee]";
      
        private SqlCommand command = new SqlCommand("", connection);
        private void dtFill3(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Status_Employee_Fill3()
        {
            dtFill3(dtStatus_Employee, qrStatus_Employee);
        }
    }
}
