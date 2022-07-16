using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Jewelry_shop.Connection
{
    public class ConnectionEmployee
    {

        public static SqlConnection connection = new SqlConnection(
                 "Data Source = DESKTOP-5S0UIB4\\MYSERVER; " +
                 " Initial Catalog=Jewelry_shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                 " User ID = SA; Password = \"timtim\"");

        public DataTable dtEmployee = new DataTable("Employee");

        public static string qrEmployee = "SELECT[ID_Authorization]," +
           "[First_Name_Employee] as \"Имя\", [Name_Employee] as \"Фамилия\", [Middle_Name_Employee] as \"Отчество\", [Experience] as \"Стаж\", [Employment_data] as \"Устроился\", [Position_ID],[ID_Position],[Job_title] as \"Должность\", [Salary] as \"Зарплата\", [Status_Employee_ID],[ID_Status_Employee],[Name_Of_Employee_Status] as \"Статус\" FROM" +
           "[dbo].[Employee] INNER JOIN [dbo].[Position]" +
           " ON [dbo].[Employee].[Position_ID]" +
           " =[dbo].[Position].[ID_Position]" +
           "INNER JOIN[dbo].[Status_Employee]" +
           "ON [dbo].[Employee].[Status_Employee_ID]" +
          "=[dbo].[Status_Employee].[ID_Status_Employee]";
     
        private SqlCommand command = new SqlCommand("", connection);
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }
        public void Employee_Fill()
        {
            dtFill(dtEmployee, qrEmployee);
        }
    }



}
