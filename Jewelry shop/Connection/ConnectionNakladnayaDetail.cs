using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionNakladnayaDetail
    {
        public int ID_Nakladnaya { get; set; }
        public string NakladnayaInfo { get; set; }




        public ConnectionNakladnayaDetail(int iD_Nakladnaya, string nakladnayaInfo)
        {
            ID_Nakladnaya = iD_Nakladnaya;
            NakladnayaInfo = nakladnayaInfo;
        }
    }
}
