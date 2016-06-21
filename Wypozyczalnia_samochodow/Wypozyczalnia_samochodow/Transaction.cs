using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    class Transaction
    {
        public uint id { get; private set; }
        public Car car { get; private set; }
        public Customer customer { get; private set; }
        private DateTime begin;
        private DateTime end;
        public Employee employee_begin { get; private set; }
        public Employee employee2 { get; private set; }
        public double price { get; private set; }
        public bool isFinished()
        {
            return end!=null;
        }
        public Transaction(Car car, Customer customer)
        {
            this.car = car;
            this.customer = customer;
            employee_begin = Rental.LoggedEmplyee;
            begin = DateTime.Now.Date;
        }
        public void finish()
        {
            employee2 = Rental.LoggedEmplyee;
            end = DateTime.Now.Date;
            price = ((end - begin).TotalDays + 1) * car.price;
        }
        public Transaction(Dictionary<string, string> d)
        {
            id = Convert.ToUInt32(d["id"]);
            car = Rental.findCar(Convert.ToUInt32(d["car"]));
            customer = Rental.findCustomer(Convert.ToUInt32(d["customer"]));
            employee_begin = Rental.findEmployee(d["employee_begin"]);
            begin = Convert.ToDateTime(d["begin"]);
            if (d["price"] != "")
                price = Convert.ToDouble(d["price"]);
            if (d["end"] != "")
                end = Convert.ToDateTime(d["end"]);
            if (d["employee_end"] != "")
                end = Convert.ToDateTime(d["employee_end"]);

        }
    }
}
