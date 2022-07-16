using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Jewelry_shop.Connection
{
    public class ConnectionJewelry
    {
        public static SqlConnection connection = new SqlConnection(
                  "Data Source = DESKTOP-5S0UIB4\\MYSERVER; " +
                  " Initial Catalog=Jewelry_shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                  " User ID = SA; Password = \"timtim\"");

        public DataTable dtJewelry = new DataTable("Jewelry");

        public static string qrJewelry = "SELECT[ID_Jewelry]," +
           "[Name_Jewelry] as \"Название украшения\", [Ammount] as \"Количество\", [Cost] as \"Цена\",[Ogranka_ID],[ID_Ogranka],[Name_Ogranka] as \"Огранка\", [Gem] as \"Камень\", [Mass_Of_Jewelry_Of_Carats] as \"Караты\",[Quality_ID],[ID_Quality],[Material] as \"Материал\" FROM" +
           "[dbo].[Jewelry] INNER JOIN [dbo].[Ogranka]" +
           " ON [dbo].[Jewelry].[Ogranka_ID]" +
           " =[dbo].[Ogranka].[ID_Ogranka]" +
           "INNER JOIN[dbo].[Quality]" +
           "ON [dbo].[Jewelry].[Quality_ID]" +
           "=[dbo].[Quality].[ID_Quality]";

        //public int ID_Jewelry { get; set; }
        //public string Name_Jewelry { get; set; }
        //public int Ammount { get; set; }
        //public string Cost { get; set; }
        //public int Ogranka_ID { get; set; }
        //public int Quality_ID { get; set; }
        //public ConnectionJewelry(int iD_Jewelry, string name_Jewelry, int ammount, string cost, int ogranka_ID, int quality_ID)
        //{
        //    ID_Jewelry = iD_Jewelry;
        //    Name_Jewelry = name_Jewelry;
        //    Ammount = ammount;
        //    Cost = cost;
        //    Ogranka_ID = ogranka_ID;
        //    Quality_ID = quality_ID;
        //}

        private SqlCommand command = new SqlCommand("", connection);
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Jewelry_Fill()
        {
            dtFill(dtJewelry, qrJewelry);
        }
    }
}
