using Jewelry_shop.Connection;
using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jewelry_shop
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Test_Click(object sender, RoutedEventArgs e)
        {
            (new Registration(null)).ShowDialog();
        }

        private void btRegistration_Click(object sender, RoutedEventArgs e)
        {
            Session.currentUser = null;

            var users = new DBProcedure().getAuthorizationList();

            foreach (var user in users)
            {
                if (user.Login == txtBoxLogin.Text && user.Password == txtBoxPas.Password)
                {
                    Session.currentUser = user;
                    AccountWindow clientPersonal = new AccountWindow();
                    clientPersonal.Show();
                    if (Session.mainWindow != null)
                    {
                        Session.mainWindow.Close();
                    }
                    Close();

                    return;
                }
            }

            MessageBox.Show("Ошибка в логине или пароле!");
        }
    }
}
