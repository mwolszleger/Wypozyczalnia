using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    class Customer
    {
        public int id { get; private set; }
        public string imie { get; set; }
        public Customer(Dictionary<string, string> d)
        {
            imie = d["imie"];
            id = Convert.ToInt32(d["id"]);
        }
        public override string ToString()
        {
            return imie;
        }
    }
}
