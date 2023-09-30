using RVIAPOON.Models;
using RVIAPOON.Models.Interfaces;
using RVIAPOON.Models.UsingModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVIAPOON.Presenters
{
    public class Presenter
    {
        IView view;
        IModel model;

        public Presenter(IView view)
        {
            this.view = view;
            model = new Model(view);

            view.Login = model.GetLogins();
            view.Emploуees = model.GetEmploуees();
        }

        public void AddEmploуee(Emploуees emploуees) =>
            model.AddEmploуee(emploуees);

        public void AddLogin(Login login) =>
            model.AddLogin(login, view.Login);

        public List<string> GetRole() =>
            model.GetRole();

        public ObservableCollection<Emploуees> TabNumSearch(int num) =>
            model.TabNumSearch(view.Emploуees, num);

        public ObservableCollection<Emploуees> FamiliaSearch(string name) =>
            model.FamiliaSearch(view.Emploуees, name);
    }
}
