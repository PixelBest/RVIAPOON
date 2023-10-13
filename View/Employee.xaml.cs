using Microsoft.Win32;
using RVIAPOON.Models.Interfaces;
using RVIAPOON.Models.UsingModels;
using RVIAPOON.Presenters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {

        Presenter presenter;
        MainWindow mainWindow;
        public Employee(MainWindow mw, Presenter p)
        {
            InitializeComponent();
            presenter = p;
            mainWindow = mw;
            dtg.ItemsSource = mainWindow.Emploуees;
        }

        private void TabNum_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Emploуees> empList = new ObservableCollection<Emploуees>();
            if (TabNum_txb.Text != "")
                empList = presenter.TabNumSearch(int.Parse(TabNum_txb.Text));
            else
            {
                MessageBox.Show("Поле не введено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }    
            if(empList.Any())
                dtg.ItemsSource = empList;
            else
                MessageBox.Show("Работников с таким табельным номером нет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            dtg.ItemsSource = mainWindow.Emploуees;
            TabNum_txb.Text = "";
            Familia_txb.Text = "";
        }

        private void Exit_Click(object sender, RoutedEventArgs e) =>
            Application.Current.Shutdown();

        private void Failia_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Emploуees> empList = new ObservableCollection<Emploуees>();
            if (Familia_txb.Text != "")
                empList = presenter.FamiliaSearch(Familia_txb.Text);
            else
            {
                MessageBox.Show("Поле не введено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (empList.Any())
                dtg.ItemsSource = empList;
            else
                MessageBox.Show("Работников с такой фамилией нет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee(mainWindow.Emploуees, presenter);
            addEmployee.ShowDialog();
        }

        private void SQL_Click(object sender, RoutedEventArgs e)
        {
            SQL sql = new SQL(presenter);
            sql.ShowDialog();
        }
    }
}
