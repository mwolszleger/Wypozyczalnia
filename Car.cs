using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    class Car
    {
        public int id { get; private set; }
        public string model { get; set; }
        public Car(Dictionary<string, string> d)
        {
            model = d["model"];
            id = Convert.ToInt32(d["id"]);
        }
        public override string ToString()
        {
            return model;
        }
       
    }
}
