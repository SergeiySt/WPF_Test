using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_wpf
{
    public class CUsers
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public CUsers() { }
        public CUsers(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
