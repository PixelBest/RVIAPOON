using RVIAPOON.Data;
using RVIAPOON.Models.Interfaces;
using RVIAPOON.Models.UsingModels;
using RVIAPOON.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RVIAPOON.Models
{
    public class Model : IModel
    {
        IView view;
        public Model(IView view)
        {
            this.view = view;
        }

        public List<Login> GetLogins()
        {
            LoginDb loginDb = new LoginDb();
            var list = loginDb.GetLogins();
            return list;
        }

        public void AddLogin(Login login, List<Login> Login)
        {
            LoginDb loginDb = new LoginDb();
            loginDb.AddLogin(login, Login);
        }

        public ObservableCollection<Emploуees> GetEmploуees()
        {
            EmployeeDb employeeDb = new EmployeeDb();
            var list = employeeDb.GetEmployee();
            return list;
        }

        public void AddEmploуee(Emploуees emploуees)
        {
            EmployeeDb employeeDb = new EmployeeDb();
            employeeDb.AddEmploуee(emploуees);
        }

        public List<string> GetRole()
        {
            List<string> list = new List<string>()
            {
                "Admin",
                "User"
            };
            return list;
        }

        public ObservableCollection<Emploуees> TabNumSearch(ObservableCollection<Emploуees> empList, int num)
        {
            ObservableCollection<Emploуees> list = new ObservableCollection<Emploуees>();
            foreach (var item in empList)
                if (item.TabNum == num)
                    list.Add(item);
            return list;
        }
        
        public ObservableCollection<Emploуees> FamiliaSearch(ObservableCollection<Emploуees> empList, string name)
        {
            ObservableCollection<Emploуees> list = new ObservableCollection<Emploуees>();
            foreach (var item in empList)
                if (item.FIO.Contains(name))
                    list.Add(item);
            return list;
        }

        public void SQLCommand(string command, DataGrid dtg)
        {
            Db db = new Db();
            db.SQLCommand(command, dtg);
        }
    }
}
