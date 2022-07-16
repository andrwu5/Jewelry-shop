using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewelry_shop.Connection;

namespace Jewelry_shop
{
    class Session
    {
        public static ConnectionAuthorization currentUser = null;
        public static MainWindow mainWindow = null;
        public static string baseDir = @"C:\Users\Андрей\Desktop\";
    }
}
