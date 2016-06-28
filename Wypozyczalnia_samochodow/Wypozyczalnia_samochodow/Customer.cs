using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    public class Customer
    {
        public uint Id { get; private set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Street { get; set; }
        public string House_number { get; set; }
        public int Flat_number { get; set; }
        public string Code_town { get; set; }
        public string Place { get; set; }
        public string Phone_number { get; set; }


        public Customer(uint id, Dictionary<string, string> d)
        {
            SetCustomerData(d);
            this.Id = id;
        }
        public Customer(Dictionary<string, string> d)
        {

            SetCustomerData(d);
            this.Id = Rental.NewCustomerId();
        }

        public void SetCustomerData(Dictionary<string, string> d)
        {

            Name = d["name"];
            Last_name = d["last_name"];
            Street = d["street"];
            House_number = (d["house_number"]);
            if (Flat_number != 0)
            {
                Flat_number = Convert.ToInt32(d["flat_number"]);
            }
            Code_town = d["code_town"];
            Place = d["place"];
            Phone_number = d["phone_number"];

        }
        public override string ToString()
        {
            return Name + " " + Last_name;
        }


    }
}
