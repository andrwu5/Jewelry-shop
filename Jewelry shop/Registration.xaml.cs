using Jewelry_shop.Connection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Jewelry_shop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {

        async Task<bool> Symb(string str)
        {
            bool znach = false;
            await Task.Run(() =>
            {
                if (
                str.Contains("?") || str.Contains("!") || str.Contains("@") ||
                str.Contains("#") || str.Contains("№") || str.Contains("~") ||
                str.Contains(";") || str.Contains("%") || str.Contains("$") ||
                str.Contains("^") || str.Contains("&") || str.Contains(":") ||
                str.Contains("*") || str.Contains("(") || str.Contains(")") ||
                str.Contains("_") || str.Contains("=") || str.Contains("+") ||
                str.Contains("/") || str.Contains("|") || str.Contains("[") ||
                str.Contains("]") || str.Contains("{") || str.Contains("}") ||
                str.Contains("<") || str.Contains(">") || str.Contains("-") ||
                str.Contains(",") || str.Contains("`") || str.Contains("."))
                    znach = true;
            });
            return znach;
        }

        bool isAdmin { get; set; }
        private ConnectionKlient connectionKlient;
        public Registration(ConnectionKlient connectionKlient, bool isConnection = false)
        {
            InitializeComponent();

            this.connectionKlient = connectionKlient;

            this.isAdmin = isAdmin;

            if (this.connectionKlient != null)
            {
                txtBoxSurname.Text = connectionKlient.First_Name_Klient;
                txtBoxName.Text = connectionKlient.Name_Klient;
                txtBoxMiddle_Name.Text = connectionKlient.Middle_Name_Klient;
                txtBoxTelephone_Number.Text = connectionKlient.Phone_Number;
                txtBoxLogin.Text = Login(connectionKlient.ID_Authorization);
                txtBoxPassword.Visibility = Visibility.Hidden;

            }
            else
            {
                txtBoxSurname.Text = string.Empty;
                txtBoxName.Text = string.Empty;
                txtBoxMiddle_Name.Text = string.Empty;
                txtBoxTelephone_Number.Text = string.Empty;
                txtBoxLogin.Text = string.Empty;
                //txtBoxPassword.Visibility = Visibility.Hidden;
            }

            if (isAdmin)
            {
                txtBoxSurname.IsReadOnly = true;
                txtBoxName.IsReadOnly = true;
                txtBoxMiddle_Name.IsReadOnly = true;
                txtBoxTelephone_Number.IsReadOnly = true;
                txtBoxLogin.IsReadOnly = true;
                txtBoxPassword.Visibility = Visibility.Hidden;
                txtBoxPassword2.Visibility = Visibility.Hidden;
                btRegistration.Content = "Close";
            }
        }

        string Login(int ID_Authorization)
        {
            var dbprocedure = new DBProcedure();
            var auths = dbprocedure.getAuthorizationList();
            foreach (var a in auths)
            {
                if (a.ID_Authorization == ID_Authorization)
                {
                    return a.Login;
                }
            }
            return string.Empty;
        }

        private async void btRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (isAdmin)
            {
                Close();
                return;
            }

            bool znach2 = await Symb(txtBoxSurname.Text);

            if (txtBoxSurname.Text == String.Empty || znach2)
            {
                MessageBox.Show("Есть ошибка в указании Фамилии");
                return;
            }

            bool znach1 = await Symb(txtBoxName.Text);

            if (txtBoxName.Text == String.Empty || znach1)
            {
                MessageBox.Show("Есть ошибка в указании Имени");
                return;
            }

            bool znach3 = await Symb(txtBoxMiddle_Name.Text);

            if (txtBoxMiddle_Name.Text == String.Empty || znach3)
            {
                MessageBox.Show("Есть ошибка в указании Отчества");
                return;
            }

            bool znach4 = await Symb(txtBoxTelephone_Number.Text);

            if (txtBoxTelephone_Number.Text == String.Empty || znach4)
            {
                MessageBox.Show("Есть ошибка в указании телефонного номера");
                return;
            }

            if (!cblicenziya.IsChecked.Value)
            {
                MessageBox.Show("Необходимо согласиться с условиями");
                return;
            }

            if (txtBoxLogin.Text == String.Empty)
            {
                MessageBox.Show("Не указан логин");
                return;
            }

            if (txtBoxPassword.Text == String.Empty)
            {
                MessageBox.Show("Не указан пароль");
                return;
            }

            if (txtBoxPassword2.Text != txtBoxPassword2.Text)
            {
                MessageBox.Show("Введенные пароли не совпадают");
                return;
            }

            if (idAuth(txtBoxLogin.Text) >= 0)
            {
                MessageBox.Show("Такой логин уже есть в базе");
                return;
            }

            Connection.ConnectionAuthorization newAuthorization = new Connection.ConnectionAuthorization(-1, txtBoxLogin.Text, txtBoxPassword.Text, 1);
            new DBProcedure().insertAuthorization(newAuthorization);

            int id_Auth = idAuth(txtBoxLogin.Text);

            Connection.ConnectionKlient klient = new Connection.ConnectionKlient(
                id_Auth,
                txtBoxSurname.Text,
                txtBoxName.Text,
                txtBoxMiddle_Name.Text,
                txtBoxTelephone_Number.Text
                );

            new DBProcedure().insertKlient(klient);

            MessageBox.Show("Регистрация прошла успешно");
            Close();
        }

        int idAuth(string Login)
        {
            var dbprocedure = new DBProcedure();
            var auths = dbprocedure.getAuthorizationList();
            foreach (var a in auths)
            {
                if (a.Login == txtBoxLogin.Text)
                {
                    return a.ID_Authorization;
                }
            }
            return -1;
        }
    }
   





    
}
