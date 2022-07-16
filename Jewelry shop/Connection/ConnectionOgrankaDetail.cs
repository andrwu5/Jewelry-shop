using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionOgrankaDetail
    {
        public int ID_Ogranka { get; set; }
        public string OgrankaInfo { get; set; }


        public ConnectionOgrankaDetail(int iD_Ogranka, string ogrankaInfo)
        {
            ID_Ogranka = iD_Ogranka;
            OgrankaInfo = ogrankaInfo;
        }
    }
}
