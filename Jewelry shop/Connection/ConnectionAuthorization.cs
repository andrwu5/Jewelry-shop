﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry_shop.Connection
{
    public class ConnectionAuthorization
    {
        public int ID_Authorization { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int ID_Role { get; set; }



        public ConnectionAuthorization(int iD_Authorization, string login, string password, int iD_Role)
        {
            ID_Authorization = iD_Authorization;
            Login = login;
            Password = password;
            ID_Role = iD_Role;
        }
    }
}
