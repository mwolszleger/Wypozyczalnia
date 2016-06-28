using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    public class Employee
    {

        public string Login { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public Employee(string login, string name, string lastName)
        {
            this.Login = login;
            this.Name = name;
            this.LastName = lastName;

        }
        public override string ToString()
        {
            return Name + " " + LastName;
        }
    }

}
