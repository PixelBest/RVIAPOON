using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RVIAPOON.Data
{
    public class Db
    {
        string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.accdb;";

        public void SQLCommand(string command, DataGrid dtg)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(command, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dtg.ItemsSource = ds.Tables[0].DefaultView;
                ds.Dispose();
                adapter.Dispose();
            }
        }
    }
}
