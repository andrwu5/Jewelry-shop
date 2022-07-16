using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    public class ConnectionCheck
    {
        public int ID_Check { get; set; }
        public int Number_Check { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Klient_ID { get; set; }


        public ConnectionCheck(int iD_Check, int number_Check, string date, string time, int klient_ID)
        {
            ID_Check = iD_Check;
            Number_Check = number_Check;
            Date = date;
            Time = time;
            Klient_ID = klient_ID;
        }
    }
}
