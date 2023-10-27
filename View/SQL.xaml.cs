using System;
using System.Collections.Generic;
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
using RVIAPOON.Presenters;
using Microsoft.Win32;

namespace RVIAPOON.View
{
    /// <summary>
    /// Логика взаимодействия для SQL.xaml
    /// </summary>
    public partial class SQL : Window
    {
        Presenter presenter;
        public SQL(Presenter p)
        {
            InitializeComponent();
            presenter = p;
        }

        private void Button_Click(object sender, RoutedEventArgs e) =>
            presenter.SQLCommand(txb.Text, dtg);

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            txb.Text = "";
            dtg.ItemsSource = null;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog FD = new SaveFileDialog();
            FD.FileName = "SQL-Запрос";
            FD.Filter = "Текстовый документ (*.sql)| *.sql|Все файлы (.)| . ";
            bool? result = FD.ShowDialog();
            if (result == true)
            {
                StreamWriter sw = new StreamWriter(FD.FileName);
                string savetext = txb.Text;
                sw.WriteLine(savetext);
                sw.Close();
                MessageBox.Show("Запрос сохранён", "Сообщение №2");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e) =>
            this.Close();

        private void ReadeRequest_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.accdb;";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.sql)| *.sql|Все файлы(*.*)| *.* ";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                OleDbConnection Connection1 = new OleDbConnection(connectionString);
                Connection1.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                string req = sr.ReadToEnd();
                txb.Text = req;
                sr.Close();
                adapter.SelectCommand = new OleDbCommand(req, Connection1);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dtg.ItemsSource = ds.Tables[0].DefaultView;
                ds.Dispose();
                adapter.Dispose();
                Connection1.Dispose();
            }
        }
    }
}
