using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionJewelryDetail
    {
        public int ID_Jewelry { get; set; }
        public string Name_Jewelry { get; set; }
        public int Ammount { get; set; }
        public string JewelryInfo { get; set; }




        public ConnectionJewelryDetail(int iD_Jewelry, string name_Jewelry, int ammount, string jewelryInfo)
        {
            ID_Jewelry = iD_Jewelry;
            Name_Jewelry = name_Jewelry;
            Ammount = ammount;
            JewelryInfo = jewelryInfo;
        }
    }
}
