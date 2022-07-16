using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    class PositionDetail
    {
        public int ID_Position { get; set; }
        public string PositionInfo { get; set; }



        public PositionDetail(int iD_Position, string positionInfo)
        {
            ID_Position = iD_Position;
            PositionInfo = positionInfo;
        }
    }
}
