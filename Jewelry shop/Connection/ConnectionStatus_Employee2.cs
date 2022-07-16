using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionStatus_Employee2
    {
        public int ID_Status_Employee { get; set; }
        public string Name_Of_Employee_Status { get; set; }
        public ConnectionStatus_Employee2(int iD_Status_Employee, string name_Of_Employee_Status)
        {
            ID_Status_Employee = iD_Status_Employee;
            Name_Of_Employee_Status = name_Of_Employee_Status;
        }
    }
}
