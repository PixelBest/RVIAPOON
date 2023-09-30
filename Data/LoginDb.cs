using RVIAPOON.Models.UsingModels;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVIAPOON.Data
{
    public class LoginDb
    {
        string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.accdb;";
        public List<Login> GetLogins()
        {
            List<Login> logins = new List<Login>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM login";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string userName = reader.GetString(1);
                string password = reader.GetString(2);
                int tabNum = reader.GetInt32(3);
                string role = reader.GetString(4);

                Login login = new Login(id, userName, password, tabNum , role);
                logins.Add(login);
            }
            return logins;
        }

        public void AddLogin(Login login, List<Login> Login)
        {
            List<int> id = new List<int>();
            foreach(var item in Login)
                id.Add(item.Id);
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            string sql = $"INSERT INTO Login VALUES ('{id.Max() + 1}','{login.UserName}', '{login.Password}', '{login.TabNum}', '{login.Role}')";
            OleDbCommand command = new OleDbCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
