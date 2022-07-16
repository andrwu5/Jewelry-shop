using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionWork_Schedule
    {
        public int ID_Work_Schedule { get; set; }
        public string Work_Days { get; set; }
        public string Work_Time { get; set; }


        public ConnectionWork_Schedule(int iD_Work_Schedule, string work_Days, string work_Time)
        {
            ID_Work_Schedule = iD_Work_Schedule;
            Work_Days = work_Days;
            Work_Time = work_Time;
        }
    }
}
