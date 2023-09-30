using RVIAPOON.Models.Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RVIAPOON.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public List<Login> Login { get; set; }
        public ObservableCollection<Emploуees> Emploуees { get; set; }


        Presenter presenter;
        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        private void Entry_Click(object sender, RoutedEventArgs e)
        {
            if (login_txb.Text != "" && password_txb.Password != "")
            {
                foreach (var item in Login)
                {
                    if (login_txb.Text == item.UserName && password_txb.Password == item.Password)
                    {
                        Employee employee = new Employee();
                        this.Close();
                        employee.ShowDialog();
                        return;
                    }
                }
                MessageBox.Show("Неправильно введены данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
                MessageBox.Show("Данные не введены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Exit_Click(object sender, RoutedEventArgs e) =>
            Application.Current.Shutdown();
    }
}
