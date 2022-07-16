using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Jewelry_shop.Connection
{
    public class ConnectionOgranka
    {
        public static SqlConnection connection = new SqlConnection(
                 "Data Source = DESKTOP-5S0UIB4\\MYSERVER; " +
                 " Initial Catalog=Jewelry_shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                 " User ID = SA; Password = \"timtim\"");

        public DataTable dtOgranka = new DataTable("Ogranka");

        public static string qrOgranka = "SELECT[ID_Ogranka]," +
            "[Name_Ogranka]+' '+[Gem]+' '+[Mass_Of_Jewelry_Of_Carats] as \"Информация об огранке\" FROM [dbo].[Ogranka]";
        //[Name_Ogranka]+' '+[Gem]+' '+[Mass_Of_Jewelry_Of_Carats] as \"Информация об огранке\"
         //"[Name_Ogranka] as \"Огранка\", [Gem] as \"Камень\", [Mass_Of_Jewelry_Of_Carats] as \"Караты\",
        //public int ID_Ogranka { get; set; }
        //public string Name_Ogranka { get; set; }
        //public string Gem { get; set; }
        //public string Mass_Of_Jewelry_Of_Carats { get; set; }
        //public ConnectionOgranka(int iD_Ogranka, string name_Ogranka, string gem, string mass_Of_Jewelry_Of_Carats)
        //{
        //    ID_Ogranka = iD_Ogranka;
        //    Name_Ogranka = name_Ogranka;
        //    Gem = gem;
        //    Mass_Of_Jewelry_Of_Carats = mass_Of_Jewelry_Of_Carats;
        //}

        public SqlCommand command = new SqlCommand("", connection);
        private void dtFill1(DataTable table, string query)
        {
            command.CommandText = query;
           connection.Open();
           table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Ogranka_Fill1()
        {
            dtFill1(dtOgranka, qrOgranka);
        }
    }
}
