using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVIAPOON.Models.UsingModels
{
    public class Login
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? TabNum { get; set; }
        public string? Role { get; set; }

        public Login(int id, string? userName, string? password, int? tabNum, string? role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            TabNum = tabNum;
            Role = role;
        }
        
        public Login(string? userName, string? password, int? tabNum, string? role)
        {
            UserName = userName;
            Password = password;
            TabNum = tabNum;
            Role = role;
        }
    }
}
