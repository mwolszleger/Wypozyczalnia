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
        public Customer(int id, Dictionary<string, string> d)
        {
            setCustomerData(d);
            this.id = id;
        }
        public Customer(Dictionary<string, string> d)
        {

           setCustomerData(d);
            this.id = Rental.NewCustomerId();
        }
        public void updateCustomer(Dictionary<string, string> d)
        {

        }
        private void setCustomerData(Dictionary<string, string> d)
        {
            imie = d["imie"];
        }
        public override string ToString()
        {
            return imie;
        }

    
    }
}
