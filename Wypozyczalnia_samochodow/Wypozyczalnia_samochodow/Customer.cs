using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    public class Customer
    {
        public int id { get; private set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string street { get; set; }
        public int house_number { get; set; }
        public int flat_number { get; set; }
        public int code_town { get; set; }
        public string place { get; set; }
        public int phone_number { get; set; }


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
            name = d["name"];
            last_name = d["last_name"];
            street = d["street"];
            house_number =Convert.ToInt32(d["house_number"]);
            flat_number =Convert.ToInt32(d["flat_number"]);
            code_town =Convert.ToInt32(d["code_town"]);
            place = d["place"];
            phone_number =Convert.ToInt32(d["phone_number"]);

        }
        public override string ToString()
        {
            return name;
        }

    
    }
}
