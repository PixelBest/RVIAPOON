using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RVIAPOON.Models.UsingModels
{
    public class Emploуees : INotifyPropertyChanged
    {
        private int tabNum;
        private string? fIO;
        private string? department;
        private string? position;

        public int TabNum
        {
            get { return tabNum; }
            set
            {
                tabNum = value;
                OnPropertyChanged("TabNum");
            }
        }
        public string? FIO
        {
            get { return fIO; }
            set
            {
                fIO = value;
                OnPropertyChanged("FIO");
            }
        }
        public string? Department
        {
            get { return department; }
            set
            {
                department = value;
                OnPropertyChanged("Department");
            }
        }
        public string? Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        public Emploуees(int tabNum, string? fIO, string? department, string? position)
        {
            TabNum = tabNum;
            FIO = fIO;
            Department = department;
            Position = position;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
