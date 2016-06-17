using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_samochodow
{
    public enum Fuels { Petrol,Diesel,Lpg}
    public class Car
    {
         // ColorColumnName, RegistrationColumnName, PriceColumnName, CarAvailabilityColumnName };


        public int id { get; private set; }
        public string brand { get; set; }
        public string model { get; set; }
        public uint year { get; set; }
        public double engine { get; set; }
        public bool climatisation { get; set; }
        public Fuels fuel { get; set; }
        public string color { get; set; }
        public string registration { get; set; }
        public double price { get; set; }
        public bool availability { get; set; }


        public Car(int id, Dictionary<string, string> d)
        {
            setCarData(d);
            this.id = id;
        }
        public Car(Dictionary<string, string> d)
        {

            setCarData(d);
            this.id = Rental.NewCarId();
        }
        public void updateCar(Dictionary<string, string> d)
        {

        }
        private void setCarData(Dictionary<string, string> d)
        {
            model = d["model"];
            brand = d["brand"];
            color = d["color"];
            registration = d["registration"];
            year = Convert.ToUInt32(d["year"]);
            engine = Convert.ToDouble(d["engine"]);
            climatisation = Convert.ToBoolean(d["climatisation"]);
            if (d["fuel"] == "petrol") fuel = Fuels.Petrol;
            else if (d["fuel"] == "lpg") fuel = Fuels.Lpg;
            else if (d["fuel"] == "diesel") fuel = Fuels.Diesel;
            price = Convert.ToDouble(d["price"]);
            availability = Convert.ToBoolean(d["availability"]);
        }
        public override string ToString()
        {
            string availaible;
            if (Rental.isCarAvailaible(this))
                availaible ="dostępny";
            else
                availaible = "niedostępny";
            return brand+" "+model+" - "+availaible;
        }

    }
}
