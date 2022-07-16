using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionPosition2
    {
        public int ID_Position { get; set; }
        public string Job_title { get; set; }
        public string Salary { get; set; }
        public ConnectionPosition2 (int iD_Position, string job_title, string salary)
        {
            ID_Position = iD_Position;
            Job_title = job_title;
            Salary = salary;
        }
    }
}
