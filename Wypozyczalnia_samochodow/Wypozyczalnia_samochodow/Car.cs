using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    public enum Fuels { Petrol, Diesel, Lpg }
    public class Car
    {



        public uint Id { get; private set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public uint Year { get; set; }
        public decimal Engine { get; set; }
        public bool Climatisation { get; set; }
        public Fuels Fuel { get; set; }
        public string Color { get; set; }
        public string Registration { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }


        public Car(uint id, Dictionary<string, string> d)
        {
            setCarData(d);
            this.Id = id;
        }
        public Car(Dictionary<string, string> d)
        {

            setCarData(d);
            this.Id = Rental.NewCarId();
        }

        public void setCarData(Dictionary<string, string> d)
        {
            Model = d["model"];
            Brand = d["brand"];
            Color = d["color"];
            Registration = d["registration"];
            Year = Convert.ToUInt32(d["year"]);
            Engine = Convert.ToDecimal(d["engine"]);
            Climatisation = Convert.ToBoolean(d["climatisation"]);
            if (d["fuel"] == "petrol") Fuel = Fuels.Petrol;
            else if (d["fuel"] == "lpg") Fuel = Fuels.Lpg;
            else if (d["fuel"] == "diesel") Fuel = Fuels.Diesel;
            Price = Convert.ToDecimal(d["price"]);
            if (d.Keys.Contains("availability"))
                Availability = Convert.ToBoolean(d["availability"]);
            else
                Availability = true;
        }
        public override string ToString()
        {
            string availaible;
            if (Rental.IsCarAvailaible(this))
                availaible = "dostępny";
            else
                availaible = "niedostępny";
            return Brand + " " + Model + " - " + availaible;
        }

    }
}
