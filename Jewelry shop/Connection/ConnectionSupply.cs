using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Jewelry_shop.Connection
{
    public class ConnectionSupply
    {
        public static SqlConnection connection = new SqlConnection(
                 "Data Source = DESKTOP-5S0UIB4\\MYSERVER; " +
                 " Initial Catalog=Jewelry_shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                 " User ID = SA; Password = \"timtim\"");

        public DataTable dtSupply = new DataTable("Supply");

        public static string qrSupply = "SELECT[ID_Supply],[Date]+' '+[Supplyer]+' '+[Ammount_Accepted_Jewelry] as \"Информация о поставке\" FROM [dbo].[Supply]";
        //public int ID_Supply { get; set; }
        //public string Date { get; set; }
        //public string Supplyer { get; set; }
        //public int Ammount_Accepted_Jewelry { get; set; }
        //public ConnectionSupply(int iD_Supply, string date, string supplyer, int ammount_Accepted_Jewelry)
        //{
        //    ID_Supply = iD_Supply;
        //    Date = date;
        //    Supplyer = supplyer;
        //    Ammount_Accepted_Jewelry = ammount_Accepted_Jewelry;
        //}
        public SqlCommand command = new SqlCommand("", connection);
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Supply_Fill()
        {
            dtFill(dtSupply, qrSupply);
        }
    }
}
