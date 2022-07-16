using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionKlientDetail
    {

        public int ID_Authorization { get; set; }
        public string KlientInfo { get; set; }





        public ConnectionKlientDetail(int iD_Authorization, string klientInfo)
        {
            ID_Authorization = iD_Authorization;
            KlientInfo = klientInfo;
        }
    }
}
