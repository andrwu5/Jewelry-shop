using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    public class ConnectionRole
    {
        public int ID_Role { get; set; }
        public string Title_Role { get; set; }
        public int Client { get; set; }
        public int Admin { get; set; }
        public int Employee { get; set; }




        public ConnectionRole(int iD_Role, string title_Role, int client, int admin, int employee)
        {
            ID_Role = iD_Role;
            Title_Role = title_Role;
            Client = client;
            Admin = admin;
            Employee = employee;
        }
    }
}
