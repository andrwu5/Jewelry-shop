using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionEmployeeDetail
    {
        public int ID_Authorization { get; set; }
        public string First_Name_Employee { get; set; }
        public string Name_Employee { get; set; }
        public string Middle_Name_Employee { get; set; }
        public string Experience { get; set; }
        public string PositionStatusInfo { get; set; }




        public ConnectionEmployeeDetail(int iD_Authorization, string first_Name_Employee, string name_Employee, string middle_Name_Employee, string experience, string positionStatusInfo)
        {
            ID_Authorization = iD_Authorization;
            First_Name_Employee = first_Name_Employee;
            Name_Employee = name_Employee;
            Middle_Name_Employee = middle_Name_Employee;
            Experience = experience;
            PositionStatusInfo = positionStatusInfo;
 

        }
    }
}
