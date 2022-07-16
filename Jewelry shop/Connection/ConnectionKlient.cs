using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    public class ConnectionKlient
    {
        public int ID_Authorization { get; set; }
        public string First_Name_Klient { get; set; }
        public string Name_Klient { get; set; }
        public string Middle_Name_Klient { get; set; }
        public string Phone_Number { get; set; }


        public ConnectionKlient(int iD_Authorization, string first_Name_Klient, string name_Klient, string middle_Name_Klient, string phone_Number)
        {
            ID_Authorization = iD_Authorization;
            First_Name_Klient = first_Name_Klient;
            Name_Klient = name_Klient;
            Middle_Name_Klient = middle_Name_Klient;
            Phone_Number = phone_Number;
        }
    }
}
