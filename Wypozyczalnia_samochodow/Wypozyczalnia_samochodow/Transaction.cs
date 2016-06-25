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
        public DateTime beginning { get; private set; }
        public DateTime end { get; private set; }
        public Employee employee_beginning { get; private set; }
        public Employee employee_end { get; private set; }
        public decimal price { get; private set; }
        public bool finished{get;private set;}
        public Transaction(Car car, Customer customer)
        {
            this.car = car;
            this.customer = customer;
            employee_beginning = Rental.LoggedEmplyee;
            beginning = DateTime.Now.Date;
            finished = false;
            id = Rental.NewTransactionrId();
        }
        public void finish()
        {
            employee_end = Rental.LoggedEmplyee;
            end = DateTime.Now.Date;
            price =Convert.ToDecimal( ((end - beginning).TotalDays + 1) *Convert.ToDouble( car.price));
            finished = true;
        }
        public Transaction(Dictionary<string, string> d)
        {
            id = Convert.ToUInt32(d["id"]);
            car = Rental.findCar(Convert.ToUInt32(d["car"]));
            customer = Rental.findCustomer(Convert.ToUInt32(d["customer"]));
            employee_beginning = Rental.findEmployee(d["employee_beginning"]);
            beginning = Convert.ToDateTime(d["beginning"]);
            if (d["price"] != "")
                price = Convert.ToDecimal(d["price"]);
            if (d["end"] != "")
            {
                end = Convert.ToDateTime(d["end"]);
                finished = true;
            }
            else finished = false;
            Console.WriteLine(d["employee_end"] + "aaa");
            if (d["employee_end"] != "")
                employee_end = Rental.findEmployee(d["employee_end"]);
           

        }
    }
}
