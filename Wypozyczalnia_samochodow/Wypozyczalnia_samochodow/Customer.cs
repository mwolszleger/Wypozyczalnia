using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    public class Customer
    {
        public uint id { get; private set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string street { get; set; }
        public string house_number { get; set; }
        public int flat_number { get; set; }
        public string code_town { get; set; }
        public string place { get; set; }
        public string phone_number { get; set; }


        public Customer(uint id, Dictionary<string, string> d)
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
        public void setCustomerData(Dictionary<string, string> d)
        {
            
            name = d["name"];
            last_name = d["last_name"];
            street = d["street"];
            house_number =(d["house_number"]);
            if (flat_number != 0)
            {
                flat_number = Convert.ToInt32(d["flat_number"]);
            }
            code_town =d["code_town"];
            place = d["place"];
            phone_number =d["phone_number"];

        }
        public override string ToString()
        {
            return name+" "+last_name;
        }
        
    
    }
}
