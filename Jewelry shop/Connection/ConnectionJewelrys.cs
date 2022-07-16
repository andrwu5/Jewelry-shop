using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionJewelrys
    {
        public int ID_Jewelry { get; set; }
        public string Name_Jewelry { get; set; }
        public int Ammount { get; set; }
        public string Cost { get; set; }
        //public int Ogranka_ID { get; set; }
        //public int Quality_ID { get; set; }
        //, int ogranka_ID, int quality_ID
        public ConnectionJewelrys(int iD_Jewelry, string name_Jewelry, int ammount, string cost)
        {
            ID_Jewelry = iD_Jewelry;
            Name_Jewelry = name_Jewelry;
            Ammount = ammount;
            Cost = cost;
           //Ogranka_ID = ogranka_ID;
           // Quality_ID = quality_ID;
        }
    }
}
