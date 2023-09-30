using RVIAPOON.Models.UsingModels;
using RVIAPOON.Presenters;
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

namespace RVIAPOON.View
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        ObservableCollection<Emploуees> Emploуees;
        Presenter presenter;
        public AddEmployee(ObservableCollection<Emploуees> e, Presenter p)
        {
            InitializeComponent();
            Emploуees = e;
            presenter = p;
            Role_cmb.ItemsSource = presenter.GetRole();
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (FIO_txb.Text != "" && Departament_txb.Text != "" && Position_txb.Text != "" && Login_txb.Text != "" && Password_txb.Text != "" && Role_cmb.Text != "")
            {
                List<int> listTabNum = new List<int>();
                foreach (var item in Emploуees)
                    listTabNum.Add(item.TabNum);
                Login login = new Login(Login_txb.Text, Password_txb.Text, listTabNum.Max() + 1, Role_cmb.SelectedItem.ToString());
                Emploуees employee = new Emploуees(listTabNum.Max() + 1, FIO_txb.Text, Departament_txb.Text, Position_txb.Text);
                presenter.AddEmploуee(employee);
                presenter.AddLogin(login);
                Emploуees.Add(employee);
                MessageBox.Show("Пользователь добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);   
            }
            else
                MessageBox.Show("Не все данные введены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Back_Click(object sender, RoutedEventArgs e) =>
            this.Close();
    }
}
