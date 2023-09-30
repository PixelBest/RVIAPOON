using RVIAPOON.Models.UsingModels;
using RVIAPOON.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVIAPOON.Data
{
    public class EmployeeDb
    {
        string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.accdb;";
        public ObservableCollection<Emploуees> GetEmployee()
        {
            ObservableCollection<Emploуees> logins = new ObservableCollection<Emploуees>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM employee";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int tabNum = reader.GetInt32(0);
                string fio = reader.GetString(1);
                string department = reader.GetString(2);
                string position = reader.GetString(3);

                Emploуees login = new Emploуees(tabNum, fio, department, position);
                logins.Add(login);
            }
            return logins;
        }

        public void AddEmploуee(Emploуees emploуees)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            string sql = $"INSERT INTO Employee VALUES ('{emploуees.TabNum}', '{emploуees.FIO}', '{emploуees.Department}', '{emploуees.Position}')";
            OleDbCommand command = new OleDbCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
