using RVIAPOON.Models.UsingModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVIAPOON.Models.Interfaces
{
    public interface IView
    {
        List<Login> Login { get; set; }
        Login User { get; set; }
        ObservableCollection<Emploуees> Emploуees { get; set; }
    }
}
