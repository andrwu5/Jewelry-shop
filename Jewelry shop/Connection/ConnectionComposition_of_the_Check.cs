using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    public class ConnectionComposition_of_the_Check
    {
        public int ID_Composition_of_the_Check { get; set; }
        public int Check_ID { get; set; }
        public int Ammount_of_Jewelry { get; set; }
        public int Jewelry_ID { get; set; }



        public ConnectionComposition_of_the_Check(int iD_Composition_of_the_Check, int check_ID, int ammount_of_Jewelry, int jewelry_ID)
        {
            ID_Composition_of_the_Check = iD_Composition_of_the_Check;
            Check_ID = check_ID;
            Ammount_of_Jewelry = ammount_of_Jewelry;
            Jewelry_ID = jewelry_ID;
        }
    }
}
