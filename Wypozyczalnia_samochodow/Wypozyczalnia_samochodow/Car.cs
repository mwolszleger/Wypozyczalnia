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
        public Car(int id,Dictionary<string, string> d)
        {
            model = d["model"];
            this.id = id;
        }
        public Car( Dictionary<string, string> d)
        {
            model = d["model"];
            this.id = Rental.NewCarId();
        }
        public override string ToString()
        {
            return model;
        }
       
    }
}
