using Jewelry_shop.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop
{
    class DBProcedure
    {
        private SqlCommand command
          = new SqlCommand("", ConnectionNakladnaya.connection);

        private SqlCommand command1
          = new SqlCommand("", ConnectionSupply.connection);

        private SqlCommand command2
         = new SqlCommand("", ConnectionJewelry.connection);

        private SqlCommand command3
         = new SqlCommand("", ConnectionOgranka.connection);

        private SqlCommand command4
          = new SqlCommand("", ConnectionQuality.connection);

        private SqlCommand command5
         = new SqlCommand("", ConnectionEmployee.connection);

        private SqlCommand command6
         = new SqlCommand("", ConnectionPosition.connection);

        private SqlCommand command7
         = new SqlCommand("", ConnectionStatus_Employee.connection);
        public void commandConfig(string config)
        {
            command.CommandType =
                System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }
        public void commandConfig1(string config)
        {
            command1.CommandType =
                System.Data.CommandType.StoredProcedure;
            command1.CommandText = "[dbo].[" + config + "]";
            command1.Parameters.Clear();
        }
        public void commandConfig2(string config)
        {
            command2.CommandType =
                System.Data.CommandType.StoredProcedure;
            command2.CommandText = "[dbo].[" + config + "]";
            command2.Parameters.Clear();
        }
        public void commandConfig3(string config)
        {
            command3.CommandType =
                System.Data.CommandType.StoredProcedure;
            command3.CommandText = "[dbo].[" + config + "]";
            command3.Parameters.Clear();
        }
        public void commandConfig4(string config)
        {
            command4.CommandType =
                System.Data.CommandType.StoredProcedure;
            command4.CommandText = "[dbo].[" + config + "]";
            command4.Parameters.Clear();
        }

        public void commandConfig5(string config)
        {
            command5.CommandType =
                System.Data.CommandType.StoredProcedure;
            command5.CommandText = "[dbo].[" + config + "]";
            command5.Parameters.Clear();
        }

        public void commandConfig6(string config)
        {
            command6.CommandType =
                System.Data.CommandType.StoredProcedure;
            command6.CommandText = "[dbo].[" + config + "]";
            command6.Parameters.Clear();
        }

        public void commandConfig7(string config)
        {
            command7.CommandType =
                System.Data.CommandType.StoredProcedure;
            command7.CommandText = "[dbo].[" + config + "]";
            command7.Parameters.Clear();
        }

        private string connectionString = @"Data Source=DESKTOP-5S0UIB4\MYSERVER;Initial Catalog=Jewelry_shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Persist Security Info = True;User ID = SA; Password = timtim";
        public SqlDependency Dependency = new SqlDependency();
        //private string connectionString = @"";
        //public DataTable dtMark = new DataTable("Mark");

        SqlConnection connection;

        public bool IsConnection { get; set; }
        public DBProcedure()
        {
            //Configuration_class configuration_Class = new Configuration_class();
            //configuration_Class.SQL_Server_Configuration_Get();
            //if (!configuration_Class.isConnection)
            //{
            //    IsConnection = false;
            //    return;
            //}
            //connection = configuration_Class.connection;
            connection = new SqlConnection(connectionString);
            IsConnection = true;
            try
            {
                connection.Open();

            }
            catch
            {
                IsConnection = false;
            }
        }

        public SqlDataReader execProc(string procName, Dictionary<string, Object> args)
        {


            SqlCommand command = new SqlCommand(procName, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            if (args != null)
            {
                foreach (var it in args)
                {
                    SqlParameter nameParam;
                    nameParam = new SqlParameter
                    {
                        ParameterName = it.Key,
                        Value = it.Value
                    };
                    command.Parameters.Add(nameParam);
                }
            }

            SqlDataReader reader = command.ExecuteReader();

            return reader;

        }
    

        public List<ConnectionAuthorization> getAuthorizationList()
        {
            List<ConnectionAuthorization> connectionAuthorization = new List<ConnectionAuthorization>();

            var reader = execProc("Authorization_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionAuthorization.Add(new ConnectionAuthorization(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3)));
                }
            }
            reader.Close();
            return connectionAuthorization;
        }

        public void insertAuthorization(Connection.ConnectionAuthorization connection)
        {
            execProc("Authorization_insert", new Dictionary<string, object> {
                { "Login", connection.Login },
                { "Password", connection.Password },
                { "ID_Role", connection.ID_Role }
            });
        }

        public void deleteAuthorization(int ID_Authorization)
        {
            execProc("Authorization_delete", new Dictionary<string, object> {
                { "ID_Authorization ", ID_Authorization }

            });
        }

        public void updateAuthorization(Connection.ConnectionAuthorization connection)
        {
            execProc("Authorization_update", new Dictionary<string, object> {
                { "ID_Authorization",connection.ID_Authorization},
                { "Login", connection.Login },
                { "Password", connection.Password },
                { "ID_Role", connection.ID_Role }
            });
        }

        public List<ConnectionKlient> getKlientList()
        {
            List<ConnectionKlient> connectionKlient = new List<ConnectionKlient>();

            var reader = execProc("Klient_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionKlient.Add(new ConnectionKlient(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                }
            }
            reader.Close();
            return connectionKlient;
        }

        public void deleteKlient(int ID_Authorization)
        {
            execProc("Klient_delete", new Dictionary<string, object> {
                { "ID_Authorization", ID_Authorization}

            });
        }

        public void updateKlient(Connection.ConnectionKlient connection)
        {
            execProc("Klient_update", new Dictionary<string, object> {
                { "ID_Authorization", connection.ID_Authorization} ,
                {"First_Name_Klient ",connection.First_Name_Klient },
                {"Name_Klient ",connection.Name_Klient },
                {"Middle_Name_Klient ",connection.Middle_Name_Klient },
                {"Phone_Number ",connection.Phone_Number }
            });

        }

        public void insertKlient(Connection.ConnectionKlient connection)
        {
            execProc("Klient_insert", new Dictionary<string, object> {
                { "ID_Authorization", connection.ID_Authorization},
                {"First_Name_Klient",connection.First_Name_Klient },
                {"Name_Klient",connection.Name_Klient },
                {"Middle_Name_Klient",connection.Middle_Name_Klient },
                {"Phone_Number",connection.Phone_Number }
            });
        }

        public List<ConnectionEmployee2> getEmployeeList()
        {
            List<ConnectionEmployee2> connectionEmployee2 = new List<ConnectionEmployee2>();

            var reader = execProc("Employee_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionEmployee2.Add(new ConnectionEmployee2(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7)));
                }
            }
            reader.Close();
            return connectionEmployee2;
        }

        public void insertEmployee(int ID_Authorization, string First_Name_Employee,
    string Name_Employee, string Middle_Name_Employee, string Experience, string Employment_data, Int32 Position_ID, Int32 Status_Employee_ID)
        {
            commandConfig5("Employee_insert");
            command5.Parameters.AddWithValue("@ID_Authorization",
               ID_Authorization);
            command5.Parameters.AddWithValue("@First_Name_Employee",
                First_Name_Employee);
            command5.Parameters.AddWithValue("@Name_Employee",
                 Name_Employee);
            command5.Parameters.AddWithValue("@Middle_Name_Employee",
                 Middle_Name_Employee);
            command5.Parameters.AddWithValue("@Experience",
                 Experience);
            command5.Parameters.AddWithValue("@Employment_data",
                 Employment_data);
            command5.Parameters.AddWithValue("@Position_ID",
                  Position_ID);
            command5.Parameters.AddWithValue("@Status_Employee_ID", Status_Employee_ID);
            ConnectionEmployee.connection.Open();
            command5.ExecuteNonQuery();
            ConnectionEmployee.connection.Close();
        }
        public void insertEmployee2(Connection.ConnectionEmployee2 connection)
        {
            execProc("Employee_insert", new Dictionary<string, object> {
                { "ID_Authorization",connection.ID_Authorization},
                { "First_Name_Employee", connection.First_Name_Employee },
                {"Name_Employee ", connection.Name_Employee },
                { "Middle_Name_Employee", connection.Middle_Name_Employee  },
                { "Experience",connection.Experience},
                { "Employment_data", connection.Employment_data },
                {"Position_ID ", connection.Position_ID },
                { "Status_Employee_ID", connection.Status_Employee_ID }
            });
        }

        public void deleteEmployee(int ID_Authorization)
        {
            execProc("Employee_delete", new Dictionary<string, object> {
                { "ID_Authorization ", ID_Authorization }

            });
        }
        public void updateEmployee(string First_Name_Employee,
       Int32 ID_Authorization, string Name_Employee, string Middle_Name_Employee, string Experience, string Employment_data, Int32 Position_ID, Int32 Status_Employee_ID)
        {
            commandConfig5("Employee_update");
            command5.Parameters.AddWithValue("@ID_Authorization",
                 ID_Authorization);
            command5.Parameters.AddWithValue("@First_Name_Employee",
                First_Name_Employee);
            command5.Parameters.AddWithValue("@Name_Employee",
                 Name_Employee);
            command5.Parameters.AddWithValue("@Middle_Name_Employee",
                 Middle_Name_Employee);
            command5.Parameters.AddWithValue("@Experience",
                 Experience);
            command5.Parameters.AddWithValue("@Employment_data",
                 Employment_data);
            command5.Parameters.AddWithValue("@Position_ID",
                  Position_ID);
            command5.Parameters.AddWithValue("@Status_Employee_ID", Status_Employee_ID);
            ConnectionEmployee.connection.Open();
            command5.ExecuteNonQuery();
            ConnectionEmployee.connection.Close();
        }
        public void updateEmployee2(Connection.ConnectionEmployee2 connection)
        {
            execProc("Employee_update", new Dictionary<string, object> {
               { "ID_Authorization",connection.ID_Authorization},
                { "First_Name_Employee", connection.First_Name_Employee },
                {"Name_Employee ", connection.Name_Employee },
                { "Middle_Name_Employee", connection.Middle_Name_Employee  },
                { "Experience",connection.Experience},
                { "Employment_data", connection.Employment_data },
                {"Position_ID ", connection.Position_ID },
                { "Status_Employee_ID", connection.Status_Employee_ID }
            });
        }

        public List<ConnectionStatus_Employee2> getStatus_EmployeeList()
        {
            List<ConnectionStatus_Employee2> connectionStatus_Employee2 = new List<ConnectionStatus_Employee2>();

            var reader = execProc("Status_Employee_select", null);

            if (reader.HasRows)
           {
                while (reader.Read())
                {
                    connectionStatus_Employee2.Add(new ConnectionStatus_Employee2(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            reader.Close();
            return connectionStatus_Employee2;
        }

        public void insertStatus_Employee(string Name_Of_Employee_Status)
        {
            commandConfig7("Status_Employee_insert");
            command7.Parameters.AddWithValue("@Name_Of_Employee_Status",
                Name_Of_Employee_Status);
            ConnectionStatus_Employee.connection.Open();
            command7.ExecuteNonQuery();
            ConnectionStatus_Employee.connection.Close();
        }
        public void insertStatus_Employee2(Connection.ConnectionStatus_Employee2 connection)
        {
            execProc("Status_Employee_insert", new Dictionary<string, object> {
                { "Name_Of_Employee_Status", connection.Name_Of_Employee_Status }
            });
        }

        public void deleteStatus_Employee(int ID_Status_Employee)
        {
            execProc("Status_Employee_delete", new Dictionary<string, object> {
                { "ID_Status_Employee", ID_Status_Employee}

            });
        }

        public void updateStatus_Employee(Int32 ID_Status_Employee,
    string Name_Of_Employee_Status)
        {
            commandConfig7("Status_Employee_update");
            command7.Parameters.AddWithValue("@ID_Status_Employee",
                 ID_Status_Employee);
            command7.Parameters.AddWithValue("@Name_Of_Employee_Status",
               Name_Of_Employee_Status);
            ConnectionStatus_Employee.connection.Open();
            command7.ExecuteNonQuery();
            ConnectionStatus_Employee.connection.Close();
        }
        public void updateStatus_Employee2(Connection.ConnectionStatus_Employee2 connection)
        {
            execProc("Status_Employee_update", new Dictionary<string, object> {
                {"ID_Status_Employee", connection.ID_Status_Employee } ,
               { "Name_Of_Employee_Status", connection.Name_Of_Employee_Status }
            });
        }

        public List<ConnectionCheck> getCheckList()
        {
            List<ConnectionCheck> connectionCheck = new List<ConnectionCheck>();

            var reader = execProc("Check_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionCheck.Add(new ConnectionCheck(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                }
            }
            reader.Close();
            return connectionCheck;
        }

        public void deleteCheck(int ID_Check)
        {
            execProc("Check_delete", new Dictionary<string, object> {
                { "ID_Check", ID_Check}

            });
        }

        public void updateCheck(Connection.ConnectionCheck connection)
        {
            execProc("Check_update", new Dictionary<string, object> {
                { "ID_Check", connection.ID_Check} ,
                {"Number_Check ",connection.Number_Check },
                {"Date ",connection.Date },
                {"Time ",connection.Time },
                {"Klient_ID ",connection.Klient_ID }
            });

        }

        public void insertCheck(Connection.ConnectionCheck connection)
        {
            execProc("Check_insert", new Dictionary<string, object> {
                {"Number_Check ",connection.Number_Check },
                {"Date ",connection.Date },
                {"Time ",connection.Time },
                {"Klient_ID ",connection.Klient_ID }
            });
        }

        public List<ConnectionComposition_of_the_Check> getComposition_of_the_CheckList()
        {
            List<ConnectionComposition_of_the_Check> connectionComposition_of_the_Check = new List<ConnectionComposition_of_the_Check>();

            var reader = execProc("Composition_of_the_Check_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionComposition_of_the_Check.Add(new ConnectionComposition_of_the_Check(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3)));
                }
            }
            reader.Close();
            return connectionComposition_of_the_Check;
        }

        public void deleteComposition_of_the_Check(int ID_Composition_of_the_Check)
        {
            execProc("Composition_of_the_Check_delete", new Dictionary<string, object> {
                { "ID_Composition_of_the_Check", ID_Composition_of_the_Check}

            });
        }

        public void updateComposition_of_the_Check(Connection.ConnectionComposition_of_the_Check connection)
        {
            execProc("Composition_of_the_Check_update", new Dictionary<string, object> {
                { "ID_Composition_of_the_Check", connection.ID_Composition_of_the_Check} ,
                {"Check_ID ",connection.Check_ID },
                {"Ammount_of_Jewelry ",connection.Ammount_of_Jewelry },
                {"Jewelry_ID ",connection.Jewelry_ID }
            });

        }

        public void insertComposition_of_the_Check(Connection.ConnectionComposition_of_the_Check connection)
        {
            execProc("Composition_of_the_Check_insert", new Dictionary<string, object> {
                {"Check_ID ",connection.Check_ID },
                {"Ammount_of_Jewelry ",connection.Ammount_of_Jewelry },
                {"Jewelry_ID ",connection.Jewelry_ID }
            });
        }

        //public List<ConnectionQuality> getQualityList()
        //{
        //    List<ConnectionQuality> connectionQuality = new List<ConnectionQuality>();

        //    var reader = execProc("Quality_select", null);

        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            connectionQuality.Add(new ConnectionQuality(reader.GetInt32(0), reader.GetString(1)));
        //        }
        //    }
        //    reader.Close();
        //    return connectionQuality;
        //}

        
            public void deleteQuality(int ID_Quality)
            {
                execProc("Quality_delete", new Dictionary<string, object> {
                { "ID_Quality", ID_Quality}

            });
            }
        

        public void insertQuality(string Material)
        {
            commandConfig4("Quality_insert");
            command4.Parameters.AddWithValue("@Material",
                Material);
            ConnectionQuality.connection.Open();
            command4.ExecuteNonQuery();
            ConnectionQuality.connection.Close();
        }
        //public void updateQuality(Connection.ConnectionQuality connection)
        //{
        //    execProc("Quality_update", new Dictionary<string, object> {
        //        { "ID_Quality", connection.ID_Quality} ,
        //        {"Material ",connection.Material }
        //    });

        //}

        public void updateQuality(string Material,
    Int32 ID_Quality)
        {
            commandConfig4("Quality_update");
            command4.Parameters.AddWithValue("@ID_Quality",
                 ID_Quality);
            command4.Parameters.AddWithValue("@Material",
                    Material);
            ConnectionQuality.connection.Open();
            command4.ExecuteNonQuery();
            ConnectionQuality.connection.Close();
        }
        //public void insertQuality(Connection.ConnectionQuality connection)
        //{
        //    execProc("Quality_insert", new Dictionary<string, object> {
        //        {"Material ",connection.Material }
        //    });
        //}

        public List<ConnectionJewelrys> getJewelrysList()
        {
            List<ConnectionJewelrys> connectionJewelrys = new List<ConnectionJewelrys>();

            var reader = execProc("Jewelry_select", null);

            if (reader.HasRows)
            {
               while (reader.Read())
               {
                   connectionJewelrys.Add(new ConnectionJewelrys(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
               }
           }
            reader.Close();
            return connectionJewelrys;
        }
       //, reader.GetInt32(4), reader.GetInt32(5)
        public void insertJewelry(string Name_Jewelry,
        Int32 Ammount, string Cost, Int32 Ogranka_ID, Int32 Quality_ID)
        {
            commandConfig2("Jewelry_insert");
            command2.Parameters.AddWithValue("@Name_Jewelry",
                Name_Jewelry);
            command2.Parameters.AddWithValue("@Ammount",
                 Ammount);
            command2.Parameters.AddWithValue("@Cost",
                 Cost);
            command2.Parameters.AddWithValue("@Ogranka_ID",
                  Ogranka_ID);
            command2.Parameters.AddWithValue("@Quality_ID", Quality_ID);
            ConnectionJewelry.connection.Open();
            command2.ExecuteNonQuery();
            ConnectionJewelry.connection.Close();
        }
        public void deleteJewelry(int ID_Jewelry)
        {
            execProc("Jewelry_delete", new Dictionary<string, object> {
                { "ID_Jewelry", ID_Jewelry}

            });
        }

        public void updateJewelry(string Name_Jewelry,
        Int32 ID_Jewelry, Int32 Ammount, string Cost, Int32 Ogranka_ID, Int32 Quality_ID)
        {
            commandConfig2("Jewelry_update");
            command2.Parameters.AddWithValue("@ID_Jewelry",
                 ID_Jewelry);
            command2.Parameters.AddWithValue("@Name_Jewelry",
                Name_Jewelry);
            command2.Parameters.AddWithValue("@Ammount",
                 Ammount);
            command2.Parameters.AddWithValue("@Cost",
                 Cost);
            command2.Parameters.AddWithValue("@Ogranka_ID",
                  Ogranka_ID);
            command2.Parameters.AddWithValue("@Quality_ID", Quality_ID);
            ConnectionJewelry.connection.Open();
            command2.ExecuteNonQuery();
            ConnectionJewelry.connection.Close();
        }
        public void updateJewelrys(Connection.ConnectionJewelrys connection)
        {
            execProc("Jewelry_update", new Dictionary<string, object> {
                { "ID_Jewelry", connection.ID_Jewelry} ,
              {"Name_Jewelry ",connection.Name_Jewelry },
                {"Ammount ",connection.Ammount },
                {"Cost ",connection.Cost },
                //{"Ogranka_ID ",connection.Ogranka_ID },
                //{"Quality_ID ",connection.Quality_ID }
            });

        }

        public void deleteJewelrys(int ID_Jewelry)
        {
            execProc("Jewelry_delete", new Dictionary<string, object> {
                { "ID_Jewelry", ID_Jewelry}
            });
        }
        public void insertJewelrys(Connection.ConnectionJewelrys connection)
        {
            execProc("Jewelry_insert", new Dictionary<string, object> {
                {"Name_Jewelry ",connection.Name_Jewelry },
                {"Ammount ",connection.Ammount },
                {"Cost ",connection.Cost }
                //{"Ogranka_ID ",connection.Ogranka_ID },
                //{"Quality_ID ",connection.Quality_ID }
            });
        }

       //public List<ConnectionOgranka> getOgrankaList()
       // {
       //     List<ConnectionOgranka> connectionOgranka = new List<ConnectionOgranka>();

       //     var reader = execProc("Ogranka_select", null);

       //    if (reader.HasRows)
       //     {
       //         while (reader.Read())
       //         {
       //             connectionOgranka.Add(new ConnectionOgranka(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
       //         }
       //     }
       //     reader.Close();
       //     return connectionOgranka;
       // }


        public void deleteOgranka(int ID_Ogranka)
        {
            execProc("Ogranka_delete", new Dictionary<string, object> {
                { "ID_Ogranka", ID_Ogranka}

            });
        }

        //public void updateOgranka(Connection.ConnectionOgranka connection)
        //{
        //    execProc("Ogranka_update", new Dictionary<string, object> {
        //        {"ID_Ogranka", connection.ID_Ogranka} ,
        //        {"Name_Ogranka",connection.Name_Ogranka},
        //       {"Gem",connection.Gem },
        //        {"Mass_Of_Jewelry_Of_Carats ",connection.Mass_Of_Jewelry_Of_Carats }
        //    });

        //}
        
        public void insertOgranka(string Name_Ogranka,
            string Gem, string Mass_Of_Jewelry_Of_Carats)
        {
            commandConfig3("Ogranka_insert");
            command3.Parameters.AddWithValue("@Name_Ogranka",
                Name_Ogranka);
            command3.Parameters.AddWithValue("@Gem",
                 Gem);
            command3.Parameters.AddWithValue("@Mass_Of_Jewelry_Of_Carats",
                 Mass_Of_Jewelry_Of_Carats);
            ConnectionOgranka.connection.Open();
            command3.ExecuteNonQuery();
            ConnectionOgranka.connection.Close();
        }
        public void updateOgranka(string Name_Ogranka,
            Int32 ID_Ogranka, string Gem, string Mass_Of_Jewelry_Of_Carats)
        {
            commandConfig3("Ogranka_update");
            command3.Parameters.AddWithValue("@ID_Ogranka",
                 ID_Ogranka);
            command3.Parameters.AddWithValue("@Name_Ogranka",
                 Name_Ogranka);
            command3.Parameters.AddWithValue("@Gem",
                           Gem);
            command3.Parameters.AddWithValue("@Mass_Of_Jewelry_Of_Carats",
                 Mass_Of_Jewelry_Of_Carats);
            ConnectionOgranka.connection.Open();
            command3.ExecuteNonQuery();
            ConnectionOgranka.connection.Close();
        }
       //public void insertOgranka(Connection.ConnectionOgranka connection)
       // {
       //     execProc("Ogranka_insert", new Dictionary<string, object> {
       //         {"Name_Ogranka ",connection.Name_Ogranka },
       //         {"Gem ",connection.Gem },
       //         {"Mass_Of_Jewelry_Of_Carats ",connection.Mass_Of_Jewelry_Of_Carats }
       //     });
       // }

        //public List<ConnectionNakladnaya> getNakladnayaList()
        //{
        //    List<ConnectionNakladnaya> connectionNakladnaya = new List<ConnectionNakladnaya>();

        //    var reader = execProc("Nakladnaya_select", null);

        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            connectionNakladnaya.Add(new ConnectionNakladnaya(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
        //        }
        //    }
        //    reader.Close();
        //    return connectionNakladnaya;
        //}

        //public void deleteNakladnaya(int ID_Nakladnaya)
        //{
        //    execProc("Nakladnaya_delete", new Dictionary<string, object> {
        //        { "ID_Nakladnaya", ID_Nakladnaya}

        //    });
        //}

        public void insertNakladnaya(string Number, Int32 Supply_ID)
        {
            commandConfig("Nakladnaya_insert");
            command.Parameters.AddWithValue("@Number",
                 Number);
            command.Parameters.AddWithValue("@Supply_ID", Supply_ID);
            ConnectionNakladnaya.connection.Open();
            command.ExecuteNonQuery();
            ConnectionNakladnaya.connection.Close();
        }
        //public void updateNakladnaya(Connection.ConnectionNakladnaya connection)
        //{
        //    execProc("Nakladnaya_update", new Dictionary<string, object> {
        //        { "ID_Nakladnaya", connection.ID_Nakladnaya} ,
        //        {"Number ",connection.Number },
        //        {"Supply_ID ",connection.Supply_ID }
        //    });

        //}

        public void updateNakladnaya(string Number,
       Int32 ID_Nakladnaya, Int32 Supply_ID)
        {
            commandConfig("Nakladnaya_update");
            command.Parameters.AddWithValue("@ID_Nakladnaya", ID_Nakladnaya);
            command.Parameters.AddWithValue("@Number", Number);
            command.Parameters.AddWithValue("@Supply_ID", Supply_ID);
            ConnectionNakladnaya.connection.Open();
            command.ExecuteNonQuery();
            ConnectionNakladnaya.connection.Close();
        }

        //public void insertNakladnaya(Connection.ConnectionNakladnaya connection)
        //{
        //    execProc("Nakladnaya_insert", new Dictionary<string, object> {
        //        {"Number ",connection.Number },
        //        {"Supply_ID ",connection.Supply_ID }
        //    });
        //}

        public void deleteNakladnaya(int ID_Nakladnaya)
        {
            commandConfig("Nakladnaya_delete");
            command.Parameters.AddWithValue("@ID_Nakladnaya", ID_Nakladnaya);
            ConnectionNakladnaya.connection.Open();
            command.ExecuteNonQuery();
            ConnectionNakladnaya.connection.Close();
        }

        //public List<ConnectionSupply> getSupplyList()
        //{
        //    List<ConnectionSupply> connectionSupply = new List<ConnectionSupply>();

        //    var reader = execProc("Supply_select", null);

        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            connectionSupply.Add(new ConnectionSupply(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
        //        }
        //    }
        //    reader.Close();
        //    return connectionSupply;
        //}
        public void insertSupply(string Date, string Supplyer, string Ammount_Accepted_Jewelry)
        {
            commandConfig1("Supply_insert");
            command1.Parameters.AddWithValue("@Date",
                Date);
            command1.Parameters.AddWithValue("@Supplyer",
                 Supplyer);
            command1.Parameters.AddWithValue("@Ammount_Accepted_Jewelry",
                 Ammount_Accepted_Jewelry);
            ConnectionSupply.connection.Open();
            command1.ExecuteNonQuery();
            ConnectionSupply.connection.Close();
        }
        public void deleteSupply(int ID_Supply)
        {
            execProc("Supply_delete", new Dictionary<string, object> {
                { "ID_Supply", ID_Supply}

           });
        }

        public void updateSupply(Int32 ID_Supply, string Date, string Supplyer, string Ammount_Accepted_Jewelry)
        {
            commandConfig1("Supply_update");
            command1.Parameters.AddWithValue("@ID_Supply",
                 ID_Supply);
            command1.Parameters.AddWithValue("@Date",
                 Date);
            command1.Parameters.AddWithValue("@Supplyer",
                 Supplyer);
            command1.Parameters.AddWithValue("@Ammount_Accepted_Jewelry",
                 Ammount_Accepted_Jewelry);
            ConnectionSupply.connection.Open();
            command1.ExecuteNonQuery();
            ConnectionSupply.connection.Close();
        }
        //public void updateSupply(Connection.ConnectionSupply connection)
        //{
        //    execProc("Supply_update", new Dictionary<string, object> {
        //        { "ID_Supply", connection.ID_Supply} ,
        //        {"Date ",connection.Date },
        //        {"Supplyer ",connection.Supplyer },
        //        {"Ammount_Accepted_Jewelry ",connection.Ammount_Accepted_Jewelry }
        //    });

        //}

        //public void insertSupply(Connection.ConnectionSupply connection)
        //{
        //    execProc("Supply_insert", new Dictionary<string, object> {
        //        {"Date ",connection.Date },
        //        {"Supplyer ",connection.Supplyer },
        //        {"Ammount_Accepted_Jewelry ",connection.Ammount_Accepted_Jewelry }
        //    });
        //}

        public List<ConnectionPosition2> getPositionList()
        {
            List<ConnectionPosition2> connectionPosition2 = new List<ConnectionPosition2>();

            var reader = execProc("Position_select", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionPosition2.Add(new ConnectionPosition2(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            }
            reader.Close();
            return connectionPosition2;
        }
        public void insertPosition(string Job_title, string Salary)
        {
            commandConfig6("Position_insert");
            command6.Parameters.AddWithValue("@Job_title",
                Job_title);
            command6.Parameters.AddWithValue("@Salary",
                 Salary);
            ConnectionPosition.connection.Open();
            command6.ExecuteNonQuery();
            ConnectionPosition.connection.Close();
        }
        public void deletePosition(int ID_Position)
        {
            execProc("Position_delete", new Dictionary<string, object> {
                { "ID_Position", ID_Position}

            });
        }

        public void updatePosition(Int32 ID_Position, string Job_title, string Salary)
        {
            commandConfig6("Position_update");
            command6.Parameters.AddWithValue("@ID_Position",
                 ID_Position);
            command6.Parameters.AddWithValue("@Job_title",
                      Job_title);
            command6.Parameters.AddWithValue("@Salary",
                 Salary);
            ConnectionPosition.connection.Open();
            command6.ExecuteNonQuery();
            ConnectionPosition.connection.Close();
        }
        public void updatePosition2(Connection.ConnectionPosition2 connection)
        {
           execProc("Position_update", new Dictionary<string, object> {
                { "ID_Position", connection.ID_Position} ,
                {"Job_title ",connection.Job_title },
                {"Salary ",connection.Salary }
            });

        }

        public void insertPosition2(Connection.ConnectionPosition2 connection)
        {
            execProc("Position_insert", new Dictionary<string, object> {
                {"Job_title ",connection.Job_title },
                {"Salary ",connection.Salary }
            });
        }

        public List<ConnectionRole> getRoleList(int idRole = -1)
        {
            List<ConnectionRole> connectionRole = new List<ConnectionRole>();

            Dictionary<string, Object> param = null;

            if (idRole >= 0)
            {
                param = new Dictionary<string, Object> { { "ID_ROLE", idRole } };
            }
            else
            {
                param = new Dictionary<string, Object> { { "ID_ROLE", "" } };
            }

            var reader = execProc("Role_select", param);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionRole.Add(new ConnectionRole(reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3),
                        reader.GetInt32(4)));
                }
            }
            reader.Close();
            return connectionRole;
        }

        public void insertRole(Connection.ConnectionRole connection)
        {
            execProc("Role_insert", new Dictionary<string, object> {
                {"Title_Role",connection.Title_Role },
                {"Client",connection.Client },
                {"Admin",connection.Admin },
                {"Employee",connection.Employee }
            });

        }

        public void deleteRole(int ID_Role)
        {
            execProc("Role_delete", new Dictionary<string, object> {
                { "ID_Role ", ID_Role }

            });
        }

        public void updateRole(Connection.ConnectionRole connection)
        {
            execProc("Role_update", new Dictionary<string, object> {
                { "ID_Role ", connection.ID_Role } ,
                {"Title_Role ",connection.Title_Role },
                {"Client",connection.Client },
                {"Admin",connection.Admin },
                {"Employee",connection.Employee }
            });

        }

        public List<PositionDetail> getPositionDetailList()
        {
            List<PositionDetail> connectionPosition = new List<PositionDetail>();

            var reader = execProc("Position_select_detail", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionPosition.Add(new PositionDetail(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            reader.Close();
            return connectionPosition;
        }

        public List<ConnectionEmployeeDetail> getEmployeeDetailList()
        {
            List<ConnectionEmployeeDetail> connectionEmployeeDetail = new List<ConnectionEmployeeDetail>();

            var reader = execProc("Employee_select_detail", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionEmployeeDetail.Add(new ConnectionEmployeeDetail(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
                }
            }
            reader.Close();
            return connectionEmployeeDetail;
        }

        public List<ConnectionSupplyDetail> getSupplyDetailList()
        {
            List<ConnectionSupplyDetail> connectionSupplyDetail = new List<ConnectionSupplyDetail>();

            var reader = execProc("Supply_select_detail", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionSupplyDetail.Add(new ConnectionSupplyDetail(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            reader.Close();
            return connectionSupplyDetail;
        }

        public List<ConnectionNakladnayaDetail> getNakladnayaDetailList()
        {
            List<ConnectionNakladnayaDetail> connectionNakladnayaDetail = new List<ConnectionNakladnayaDetail>();

            var reader = execProc("Nakladnaya_select_detail", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionNakladnayaDetail.Add(new ConnectionNakladnayaDetail(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            reader.Close();
            return connectionNakladnayaDetail;
        }

        public List<ConnectionOgrankaDetail> getOgrankaDetailList()
        {
            List<ConnectionOgrankaDetail> connectionOgrankaDetail = new List<ConnectionOgrankaDetail>();

            var reader = execProc("Ogranka_select_detail", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionOgrankaDetail.Add(new ConnectionOgrankaDetail(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            reader.Close();
            return connectionOgrankaDetail;
        }

        public List<ConnectionJewelryDetail> getJewelryDetailList()
        {
            List<ConnectionJewelryDetail> connectionJewelryDetail = new List<ConnectionJewelryDetail>();

            var reader = execProc("Jewelry_select_detail", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionJewelryDetail.Add(new ConnectionJewelryDetail(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                }
            }
            reader.Close();
            return connectionJewelryDetail;
        }

        public List<ConnectionKlientDetail> getKlientDetailList()
        {
            List<ConnectionKlientDetail> connectionKlientDetail = new List<ConnectionKlientDetail>();

            var reader = execProc("Klientss_select_detail", null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    connectionKlientDetail.Add(new ConnectionKlientDetail(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            reader.Close();
            return connectionKlientDetail;
        }
    }
}
