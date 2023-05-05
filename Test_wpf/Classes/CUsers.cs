using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_wpf.Classes
{
    internal class CUsers
    {
        private class User
        {
            private string Name { get; set; }
            private string Surname { get; set; }

           public User(string name, string surname) 
            {
                Name = name;
                Surname = surname;
            }
        }
    }
}
