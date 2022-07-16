using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionEmployee2
    {
        public int ID_Authorization { get; set; }
        public string First_Name_Employee { get; set; }
        public string Name_Employee { get; set; }
        public string Middle_Name_Employee { get; set; }
        public string Experience { get; set; }
        public string Employment_data { get; set; }
        public int Position_ID { get; set; }
        public int Status_Employee_ID { get; set; }
        public ConnectionEmployee2 (int iD_Authorization, string first_Name_Employee, string name_Employee, string middle_Name_Employee, string experience, string employment_data, int position_ID, int status_Employee_ID)
        {
            ID_Authorization = iD_Authorization;
           First_Name_Employee = first_Name_Employee;
           Name_Employee = name_Employee;
            Middle_Name_Employee = middle_Name_Employee;
            Experience = experience;
            Employment_data = employment_data;
            Position_ID = position_ID;
            Status_Employee_ID = status_Employee_ID;

        }
    }
}
