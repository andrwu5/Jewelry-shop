using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class ConnectionSupplyDetail
    {

        public int ID_Supply { get; set; }
        public string SupplyInfo { get; set; }




        public ConnectionSupplyDetail(int iD_Supply, string supplyInfo)
        {
            ID_Supply = iD_Supply;
            SupplyInfo = supplyInfo;

        }
    }
        
}
