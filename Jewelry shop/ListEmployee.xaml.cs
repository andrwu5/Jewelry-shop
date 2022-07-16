using System;
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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Jewelry_shop.Connection;
using System.Threading;

namespace Jewelry_shop
{
    /// <summary>
    /// Логика взаимодействия для ListEmployee.xaml
    /// </summary>
    public partial class ListEmployee : Window
    {
        private Connection.ConnectionEmployee connectionEmployee;
        private Connection.ConnectionPosition2 connectionPosition2;
        private Connection.ConnectionStatus_Employee2 connectionStatus_Employee2;
        List<Connection.ConnectionEmployee> Employes;
        //List<Connection.ConnectionEmployeeDetail> EmployeeDetail;
        List<Connection.ConnectionPosition2> Position;
        //List<Connection.PositionDetail> PositionDetail;
        List<Connection.ConnectionStatus_Employee2> Status_Employee;
        private Connection.ConnectionEmployee2 connectionEmployee2;
        List<Connection.ConnectionEmployee> Employees2;
        private List<Connection.ConnectionRole> roles;

        public string extension = string.Empty;
        private string QR = "";
       

        public ListEmployee()
        {
            InitializeComponent();
            roles = new DBProcedure().getRoleList();
            ObservableCollection<string> listPositions = new ObservableCollection<string>();
            foreach (var it in roles)
            {
                listPositions.Add(it.Title_Role);
            }
            this.lbPosition.ItemsSource = listPositions;

            ObservableCollection<string> listStatus_Employee = new ObservableCollection<string>();
            foreach (var it in roles)
            {
                listPositions.Add(it.Title_Role);
            }
            this.lbStatus_Employee.ItemsSource = listStatus_Employee;

            this.connectionEmployee2 = connectionEmployee2;

            if (this.connectionEmployee != null)
            {
                tbSurname_Employee.Text = this.connectionEmployee2.First_Name_Employee;
                tbName_Employee.Text = this.connectionEmployee2.Name_Employee;
                tbMiddleName_Employee.Text = this.connectionEmployee2.Middle_Name_Employee;
                tbExperience.Text = this.connectionEmployee2.Experience;
                tbEmployment_data.Text = this.connectionEmployee2.Employment_data;

                lbPosition.IsEnabled = false;
                txtBoxLogin.Visibility = Visibility.Hidden;
                txtBoxPassword.Visibility = Visibility.Hidden;
                txtBoxPassword2.Visibility = Visibility.Hidden;
                lbPassword.Visibility = Visibility.Hidden;
                lbPassword2.Visibility = Visibility.Hidden;
                labelLogin.Visibility = Visibility.Hidden;

                int idlistRoles = -1;
                for (idlistRoles = 0; idlistRoles < roles.Count; idlistRoles++)
                {
                    Connection.ConnectionAuthorization authorization = null;
                    foreach (var it in new DBProcedure().getAuthorizationList())
                    {
                        if (it.ID_Authorization == this.connectionEmployee2.ID_Authorization)
                        {
                            authorization = it;
                            break;
                        }
                    }
                    if (authorization != null)
                    {
                        if (roles[idlistRoles].ID_Role == authorization.ID_Role)
                        {
                            break;
                        }
                    }

                }
                lbPosition.SelectedIndex = idlistRoles;
                lbStatus_Employee.SelectedIndex = idlistRoles;
            }
            else
            {
                tbSurname_Employee.Text = string.Empty;
                tbName_Employee.Text = string.Empty;
                tbMiddleName_Employee.Text = string.Empty;
                tbExperience.Text = string.Empty;
                tbEmployment_data.Text = string.Empty;
            }
        }

       

        private void Window_Activated(object sender, EventArgs e)
        {
            Action action = () =>
            {
                Status_Employee = (new DBProcedure()).getStatus_EmployeeList();
                lbStatus_Employee.ItemsSource = Status_Employee;
            };

            Dispatcher.Invoke(action);

            // EmployeeDetail = (new DBProcedure()).getEmployeeDetailList();
            // dgListEmployee.ItemsSource = EmployeeDetail;
            //PositionDetail = (new DBProcedure()).getPositionDetailList();
            //lbPosition.ItemsSource = PositionDetail;
            //lbPosition.SelectedValuePath = "ID_Position";
            //lbPosition.DisplayMemberPath = "PositionInfo";

            //lbStatus_Employee.SelectedValuePath = "ID_Status_Employee";
            //lbStatus_Employee.DisplayMemberPath = "Name_Of_Employee_Status";

        }

        DBProcedure procedures = new DBProcedure();

        private void dgFill(string qr)
        {
            ConnectionEmployee connection = new ConnectionEmployee();
            ConnectionEmployee.qrEmployee = qr;
            connection.Employee_Fill();
            dgListEmployee.ItemsSource = connection.dtEmployee.DefaultView;
            dgListEmployee.Columns[0].Visibility = Visibility.Hidden;
            dgListEmployee.Columns[6].Visibility = Visibility.Hidden;
            dgListEmployee.Columns[7].Visibility = Visibility.Hidden;
            dgListEmployee.Columns[10].Visibility = Visibility.Hidden;
            dgListEmployee.Columns[11].Visibility = Visibility.Hidden;
        }

        private void lbFill1()
        {
            ConnectionPosition connection = new ConnectionPosition();
            connection.Position_Fill2();
            lbPosition.ItemsSource
             = connection.dtPosition.DefaultView;
            lbPosition.SelectedValuePath = "ID_Position";
            lbPosition.DisplayMemberPath = "Информация о должности";


        }

        private void lbFill2()
        {
            ConnectionStatus_Employee connection = new ConnectionStatus_Employee();
            connection.Status_Employee_Fill3();
            lbStatus_Employee.ItemsSource
             = connection.dtStatus_Employee.DefaultView;
            lbStatus_Employee.SelectedValuePath = "ID_Status_Employee";
            lbStatus_Employee.DisplayMemberPath = "Статус";

        }
        private void btInsert_Employee_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().insertEmployee(new Connection.ConnectionEmployee(
            //               -1,
            //               tbSurname_Employee.Text,
            //               tbName_Employee.Text,
            //               tbMiddleName_Employee.Text,
            //               tbExperience.Text,
            //               tbEmployment_data.Text,
            //               Convert.ToInt32(lbPosition.SelectedValue),
            //               Convert.ToInt32(lbStatus_Employee.SelectedValue)
            //               ));
            //Employee = (new DBProcedure()).getEmployeeList();
            //dgListEmployee.ItemsSource = Employee;
            int idAuth(string Login)
            {
                var dbprocedures = new DBProcedure();
                var auths = dbprocedures.getAuthorizationList();
                foreach (var a in auths)
                {
                    if (a.Login == txtBoxLogin.Text)
                    {
                        return a.ID_Authorization;
                    }
                }
                return -1;
            }

            Connection.ConnectionAuthorization newAuthorization = new Connection.ConnectionAuthorization(-1, txtBoxLogin.Text, txtBoxPassword.Text, 2);
            new DBProcedure().insertAuthorization(newAuthorization);

            int ID_Position = Position[lbPosition.SelectedIndex].ID_Position;
            int ID_Status_Employee = Status_Employee[lbStatus_Employee.SelectedIndex].ID_Status_Employee;
            int id_Auth = idAuth(txtBoxLogin.Text);

            Connection.ConnectionEmployee2 employee2 = new Connection.ConnectionEmployee2(
                id_Auth,
                tbSurname_Employee.Text,
                tbSurname_Employee.Text,
                tbMiddleName_Employee.Text,
                tbExperience.Text,
                tbEmployment_data.Text,
                ID_Position,
                ID_Status_Employee
                );

            new DBProcedure().insertEmployee2(employee2);
            MessageBox.Show("Регистрация прошла успешно");
            dgFill(QR);

            //procedures.insertEmployee(tbSurname_Employee.Text, tbName_Employee.Text, tbMiddleName_Employee.Text, tbExperience.Text, tbEmployment_data.Text, Convert.ToInt32(lbPosition.SelectedValue), Convert.ToInt32(lbStatus_Employee.SelectedValue));
            //dgFill(QR);
        }

        private void btUpdate_Employee_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().updateEmployee(new Connection.ConnectionEmployee(
            //              this.connectionEmployee.ID_Authorization,
            //              tbSurname_Employee.Text,
            //              tbName_Employee.Text,
            //              tbMiddleName_Employee.Text,
            //              tbExperience.Text,
            //              tbEmployment_data.Text,
            //              Convert.ToInt32(lbPosition.SelectedValue),
            //              Convert.ToInt32(lbStatus_Employee.SelectedValue)
            //              ));
            //Employee = (new DBProcedure()).getEmployeeList();
            //dgListEmployee.ItemsSource = Employee;
            try
            {
                DataRowView ID = (DataRowView)dgListEmployee.SelectedItems[0];
                if (ID == null)
                    MessageBox.Show("", "");
                else
                    procedures.updateEmployee(tbSurname_Employee.Text, Convert.ToInt32(ID["ID_Authorization"]), tbName_Employee.Text, tbMiddleName_Employee.Text, tbExperience.Text, tbEmployment_data.Text, Convert.ToInt32(lbPosition.SelectedValue), Convert.ToInt32(lbStatus_Employee.SelectedValue));
                dgFill(QR);
            }
            catch
            {

            }
        }

        private void btDelete_Employee_Click(object sender, RoutedEventArgs e)
        {
            //int selectedIndex = dgListEmployee.SelectedIndex;
            //new DBProcedure().deleteEmployee(Employee[selectedIndex].ID_Authorization);
            //MessageBox.Show("Операция выполнена");
            //Employee = (new DBProcedure()).getEmployeeList();
            //dgListEmployee.ItemsSource = Employee;
            switch (MessageBox.Show("Удалить выбранную запись?",
             "Удаление записи", MessageBoxButton.YesNo,
             MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    DataRowView ID =
                      (DataRowView)dgListEmployee.SelectedItems[0];
                    procedures.deleteEmployee(
                       Convert.ToInt32(ID["ID_Authorization"]));
                    dgFill(QR);
                    break;
            }
        }

        private void btInsert_Position_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().insertPosition(new Connection.ConnectionPosition(
            //                -1,
            //                tbJob_title.Text,
            //                tbSalary.Text
            //                ));
            //PositionDetail = (new DBProcedure()).getPositionDetailList();
            //lbPosition.ItemsSource = PositionDetail;
            //lbPosition.SelectedValuePath = "ID_Position";
            //lbPosition.DisplayMemberPath = "PositionInfo";
        }

        private void btUpdate_Position_Click(object sender, RoutedEventArgs e)
        {
            //new DBProcedure().updatePosition(new Connection.ConnectionPosition(
            //               this.connectionPosition.ID_Position,
            //                tbJob_title.Text,
            //                tbSalary.Text
            //                ));
            //PositionDetail = (new DBProcedure()).getPositionDetailList();
            //lbPosition.ItemsSource = PositionDetail;
            //lbPosition.SelectedValuePath = "ID_Position";
            //lbPosition.DisplayMemberPath = "PositionInfo";
        }

        private void btDelete_Position_Click(object sender, RoutedEventArgs e)
        {
            //int selectedIndex = lbPosition.SelectedIndex;
            //new DBProcedure().deletePosition(Position[selectedIndex].ID_Position);
            //MessageBox.Show("Операция выполнена");
            //PositionDetail = (new DBProcedure()).getPositionDetailList();
            //lbPosition.ItemsSource = PositionDetail;
            //lbPosition.SelectedValuePath = "ID_Position";
            //lbPosition.DisplayMemberPath = "PositionInfo";
        }

        private void btInsert_Status_Employee_Click(object sender, RoutedEventArgs e)
        {
            new DBProcedure().insertStatus_Employee2(new Connection.ConnectionStatus_Employee2(
                            -1,
                           tbStatus_Employee.Text
                            ));
            Status_Employee = (new DBProcedure()).getStatus_EmployeeList();
            lbStatus_Employee.ItemsSource = Status_Employee;
            lbStatus_Employee.SelectedValuePath = "ID_Status_Employee";
            lbStatus_Employee.DisplayMemberPath = "Name_Of_Employee_Status";
            //procedures.insertStatus_Employee(tbStatus_Employee.Text);
            Status_Employee = (new DBProcedure()).getStatus_EmployeeList();
            lbStatus_Employee.ItemsSource = Status_Employee;
        }

        private void btUpdate_Status_Employee_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lbStatus_Employee.SelectedIndex;
            var ap = new DBProcedure().getStatus_EmployeeList();
            foreach (var it in ap)
            {
                if (it.ID_Status_Employee == Status_Employee[selectedIndex].ID_Status_Employee) ;
                {
                    connectionStatus_Employee2 = it;
                    break;
                }
            }

            if (tbStatus_Employee.Text == string.Empty)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            new DBProcedure().updateStatus_Employee2(new Connection.ConnectionStatus_Employee2(
                    this.connectionStatus_Employee2.ID_Status_Employee,
                     tbStatus_Employee.Text
               ));
            Status_Employee = (new DBProcedure()).getStatus_EmployeeList();
            lbStatus_Employee.ItemsSource = Status_Employee;
            //try
            //{
            //    DataRowView ID = (DataRowView)lbStatus_Employee.SelectedItems[0];
            //    if (ID == null)
            //        MessageBox.Show("", "");
            //    else
            //        procedures.updateStatus_Employee(Convert.ToInt32(ID["ID_Status_Employee"]), tbStatus_Employee.Text);
            //    Status_Employee = (new DBProcedure()).getStatus_EmployeeList();
            //    lbStatus_Employee.ItemsSource = Status_Employee;
            //}
            //catch
            //{

            //}
        }

        private void btDelete_Status_Employee_Click(object sender, RoutedEventArgs e)
        {
            //int selectedIndex = lbStatus_Employee.SelectedIndex;
            //new DBProcedure().deleteStatus_Employee(Status_Employee[selectedIndex].ID_Status_Employee);
            //MessageBox.Show("Операция выполнена");
            //Status_Employee = (new DBProcedure()).getStatus_EmployeeList();
            //lbStatus_Employee.ItemsSource = Status_Employee;
            switch (MessageBox.Show("Удалить выбранную запись?",
               "Удаление записи", MessageBoxButton.YesNo,
               MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    procedures.deleteStatus_Employee(
                    Convert.ToInt32(lbStatus_Employee.
                    SelectedValue.ToString()));
                    Status_Employee = (new DBProcedure()).getStatus_EmployeeList();
                    lbStatus_Employee.ItemsSource = Status_Employee;
                    break;
            }
        }

        //private void btFilter_Click(object sender, RoutedEventArgs e)
        //{
        //    string newQR = QR + " where [First_Name_Employee] like '%" + tbSearch.Text + "%' or " +
        //       "[Name_Employee] like '%" + tbSearch.Text + "%' or " +
        //       "[Middle_Name_Employee] like '%" + tbSearch.Text + "%'or " +
        //       "[Experience] like '%" + tbSearch.Text + "%'or " +
        //       "[Employment_data] like '%" + tbSearch.Text + "%' or " +
        //       "[Position_ID] like '%" + tbSearch.Text + "%'or " +
        //       "[Status_Employee_ID] like '%" + tbSearch.Text + "%'";
        //    dgFill(QR);
        //}

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgListEmployee.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[5].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[6].ToString() == tbSearch.Text ||
                    dataRow.Row.ItemArray[7].ToString() == tbSearch.Text)
                {
                    dgListEmployee.SelectedItem = dataRow;
                }
            }
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Spravochnik spravochnik = new Spravochnik();
            spravochnik.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = ConnectionEmployee.qrEmployee;
            dgFill(QR);
           // lbFill1();
            //lbFill2();
            Position = (new DBProcedure()).getPositionList();
            lbPosition.ItemsSource = Position;
            lbPosition.SelectedValuePath = "ID_Position";
            lbPosition.DisplayMemberPath = "Job_title";
            Status_Employee = (new DBProcedure()).getStatus_EmployeeList();
            lbStatus_Employee.ItemsSource = Status_Employee;
            lbStatus_Employee.SelectedValuePath = "ID_Status_Employee";
            lbStatus_Employee.DisplayMemberPath = "Name_Of_Employee_Status";
        }
    }
 

        
    
}
