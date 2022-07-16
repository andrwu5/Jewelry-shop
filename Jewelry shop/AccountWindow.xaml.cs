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
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        private List<Button> buttons = new List<Button>();
        public AccountWindow()
        {
            var roleList = new DBProcedure().getRoleList(Session.currentUser.ID_Role);
            InitializeComponent();
            if (roleList.Count == 1)
            {
                buttons.Clear();

                var role = roleList[0];

                this.Title = role.Title_Role;

               

                if (role.Client == 1)
                {
                    buttons.Add(createButton("Главная страница", Button_Handle_MainWindow));
                }
                if (role.Admin == 1)
                {
                    buttons.Add(createButton("Администратор", Button_Handle_Spravochnik));
                }

                if (role.Employee == 1)
                {
                    buttons.Add(createButton("Справочник клиентов", Button_Handle_Klients));
                    buttons.Add(createButton("Справочник украшений", Button_Handle_Jewelry));
                    buttons.Add(createButton("Справочник огранок", Button_Handle_Ogranka));

                }



                for (int i = 0; i < buttons.Count; i++)
                {

                    sp.Children.Add(buttons[i]);
                }

            }
        }
        private Button createButton(string content, RoutedEventHandler handler)
        {
            var b = new Button();
            b.Content = content;
            b.Click += handler;
            return b;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Button_Handle_Spravochnik(object sender, RoutedEventArgs e)
        {
            var window = new Spravochnik();
            window.ShowDialog();
        }

        private void Button_Handle_MainWindow(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.ShowDialog();
        }

        private void Button_Handle_Klients(object sender, RoutedEventArgs e)
        {
            var window = new Klients();
            window.ShowDialog();
        }

        private void Button_Handle_Jewelry(object sender, RoutedEventArgs e)
        {
            var window = new Jewelry();
            window.ShowDialog();
        }

        private void Button_Handle_Ogranka(object sender, RoutedEventArgs e)
        {
            var window = new Ogranka();
            window.ShowDialog();
        }
    }
}
