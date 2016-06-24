using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    public class Employee
    {

        public string login { get; private set; }
        public string name { get; private set; }
        public string lastName { get; private set; }
        public Employee(string login, string name, string lastName)
        {
            this.login = login;
            this.name = name;
            this.lastName = lastName;
           
        }
        public override string ToString()
        {
            return name + " " + lastName;
        }
    }
    
}
