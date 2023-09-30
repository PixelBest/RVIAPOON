using RVIAPOON.Models.UsingModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVIAPOON.Models.Interfaces
{
    public interface IModel
    {
        List<Login> GetLogins();
        ObservableCollection<Emploуees> GetEmploуees();
        void AddEmploуee(Emploуees emploуees);
        List<string> GetRole();
        void AddLogin(Login login, List<Login> Login);
        ObservableCollection<Emploуees> TabNumSearch(ObservableCollection<Emploуees> empList, int num);
        ObservableCollection<Emploуees> FamiliaSearch(ObservableCollection<Emploуees> empList, string name);
    }
}
