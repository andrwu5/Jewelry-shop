﻿using Jewelry_shop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.Integration;

namespace Jewelry_shop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Андрей\source\repos\Jewelry shop\Jewelry shop\bin\Debug\Jewelry shop.exe");
        }
    }
}
