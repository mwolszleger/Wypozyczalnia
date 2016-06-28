using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    class Transaction
    {
        public uint Id { get; private set; }
        public Car Car { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime Beginning { get; private set; }
        public DateTime End { get; private set; }
        public Employee Employee_beginning { get; private set; }
        public Employee Employee_end { get; private set; }
        public decimal Price { get; private set; }
        public bool Finished { get; private set; }
        public Transaction(Car car, Customer customer)
        {
            this.Car = car;
            this.Customer = customer;
            Employee_beginning = Rental.LoggedEmplyee;
            Beginning = DateTime.Now.Date;
            Finished = false;
            Id = Rental.NewTransactionrId();
        }
        public void Finish()
        {
            Employee_end = Rental.LoggedEmplyee;
            End = DateTime.Now.Date;
            Price = Convert.ToDecimal(((End - Beginning).TotalDays + 1) * Convert.ToDouble(Car.Price));
            Finished = true;
        }
        public Transaction(Dictionary<string, string> d)
        {
            Id = Convert.ToUInt32(d["id"]);
            Car = Rental.FindCar(Convert.ToUInt32(d["car"]));
            Customer = Rental.FindCustomer(Convert.ToUInt32(d["customer"]));
            Employee_beginning = Rental.FindEmployee(d["employee_beginning"]);
            Beginning = Convert.ToDateTime(d["beginning"]);
            if (d["price"] != "")
                Price = Convert.ToDecimal(d["price"]);
            if (d["end"] != "")
            {
                End = Convert.ToDateTime(d["end"]);
                Finished = true;
            }
            else Finished = false;
           
            if (d["employee_end"] != "")
                Employee_end = Rental.FindEmployee(d["employee_end"]);


        }
    }
}
