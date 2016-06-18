using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace Wypozyczalnia_samochodow
{
    static class DBConnectionMySql
    {
        public static string Server { get; set; }
        public static string User { get; set; }
        public static string Passwd { private get; set; }
        public static uint Port { get; set; }
        public static string FileName { get; set; }
        static DBConnectionMySql()
        {
            Server = "127.0.0.1";
            User = "root";
            Passwd = "";
            Port = 3306;

        }
        //nazwa tabeli z autami
        private static readonly string CarsTableName = "cars";
        //nazwy kolumn w tabeli z autami
        private static readonly string CarIdColumnName = "id";
        private static readonly string BrandColumnName = "brand";
        private static readonly string ModelColumnName = "model";
        private static readonly string YearColumnName = "year_of_construction";
        private static readonly string EngineColumnName = "engine_displacement";
        private static readonly string ClimatisationColumnName = "climatisation";
        private static readonly string FuelColumnName = "fuel";
        private static readonly string ColorColumnName = "color";
        private static readonly string RegistrationColumnName = "registration_number";
        private static readonly string PriceColumnName = "price";
        private static readonly string CarAvailabilityColumnName = "availability";


        public static MySqlConnection CreatConnection(string DataBaseName)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = Server;
            builder.UserID = User;
            builder.Password = Passwd;
            builder.Port = Port;
            builder.Database = DataBaseName;
            MySqlConnection conn = new MySqlConnection(builder.ConnectionString);
            return conn;

        }


        public static void OpenConnection(MySqlConnection conn)
        {
            conn.Open();
        }

        public static void CloseConnection(MySqlConnection conn)
        {
            conn.Close();
        }

        //zwraca listę wszystkich aut, załadowanych z bazy danych
        public static List<Car> SelectAllCars(MySqlConnection conn)
        {
            List<Car> cars = new List<Car>();
            string[] tableNames = new string[] { CarIdColumnName, BrandColumnName, ModelColumnName, YearColumnName, EngineColumnName, ClimatisationColumnName, FuelColumnName, ColorColumnName, RegistrationColumnName, PriceColumnName, CarAvailabilityColumnName };
            string queryText = CreateSelectQuerry(tableNames, CarsTableName);

            MySqlCommand command = new MySqlCommand(queryText, conn);

            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                var attributes = new Dictionary<string, string>();
                attributes.Add("brand", dr[1].ToString());
                attributes.Add("model", dr[2].ToString());
                attributes.Add("year", dr[3].ToString());
                attributes.Add("engine", dr[4].ToString().Replace('.', CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0]));
                attributes.Add("climatisation", dr[5].ToString());
                attributes.Add("fuel", dr[6].ToString());
                attributes.Add("color", dr[7].ToString());
                attributes.Add("registration", dr[8].ToString());
                attributes.Add("price", dr[9].ToString().Replace('.', CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0]));
                attributes.Add("availability", dr[10].ToString());
                cars.Add(new Car(Convert.ToUInt32(dr[0]), attributes));

            }
            dr.Close();
            return cars;

        }
        //dodaje do pliku zapytanie (dodanie do bazy lub zmiana), któe wykona się przy wylogowaniu
        public static void AddQuerry(string s)
        {
            StreamWriter file = new StreamWriter("file.txt", true);
            file.WriteLine(s);
            file.Close();
        }
        public static void addCar(Car c)
        {
            var attributes = new Dictionary<string, string>();
            attributes.Add(BrandColumnName, c.brand);
            attributes.Add(ModelColumnName, c.model);
            attributes.Add(YearColumnName, c.year.ToString());
            attributes.Add(EngineColumnName, c.engine.ToString().Replace('.', CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0]));
            attributes.Add(ClimatisationColumnName, c.climatisation.ToString());
            attributes.Add(FuelColumnName, c.fuel.ToString());
            attributes.Add(ColorColumnName, c.color);
            attributes.Add(RegistrationColumnName, c.registration);
            attributes.Add(PriceColumnName, c.price.ToString().Replace(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0], '.'));
            attributes.Add(CarAvailabilityColumnName, c.availability.ToString());

            AddQuerry(CreateInsertQuerry(attributes, CarsTableName));
        }
        public static void updateCar(Car c)
        {
            var attributes = new Dictionary<string, string>();
            attributes.Add(BrandColumnName, c.brand);
            attributes.Add(ModelColumnName, c.model);
            attributes.Add(YearColumnName, c.year.ToString());
            attributes.Add(EngineColumnName, c.engine.ToString().Replace('.', CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0]));
            attributes.Add(ClimatisationColumnName, c.climatisation.ToString());
            attributes.Add(FuelColumnName, c.fuel.ToString());
            attributes.Add(ColorColumnName, c.color);
            attributes.Add(RegistrationColumnName, c.registration);
            attributes.Add(PriceColumnName, c.price.ToString().Replace(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0], '.'));
            attributes.Add(CarAvailabilityColumnName, c.availability.ToString());

            AddQuerry(CreateUpdateQuerry(attributes, CarsTableName, c.id));
        }
        public static void ExecuteQuerries(MySqlConnection conn)
        {

            string line;
            if (!File.Exists("file.txt"))
                return;
            try
            {
                StreamReader file = new System.IO.StreamReader("file.txt");
                while ((line = file.ReadLine()) != null)
                {
                    MySqlCommand command = new MySqlCommand(line, conn);

                    MySqlDataReader dr = command.ExecuteReader();
                    dr.Close();
                }

                file.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                File.Delete("file.txt");
            }
        }

        private static string CreateSelectQuerry(IEnumerable<String> Columns, string TableName)
        {
            string querry = "select ";
            foreach (var it in Columns)
            {
                querry += it;
                querry += ",";
            }
            //usunięcie ostatniego przecinka
            querry = querry.Remove(querry.Length - 1, 1);
            querry += " from ";
            querry += TableName;
            return querry;
        }

        public static List<Customer> SelectAllCustomers(MySqlConnection conn)
        {
            List<Customer> customer = new List<Customer>();
            string queryText = "SELECT id,imie FROM customer";

            MySqlCommand command = new MySqlCommand(queryText, conn);

            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                var attributes = new Dictionary<string, string>();
                attributes.Add("imie", dr[1].ToString());
                customer.Add(new Customer(Convert.ToInt32(dr[0]), attributes));

            }
            dr.Close();
            return customer;

        }
        public static void addCustomer(Customer cs)
        {
            AddQuerry("insert into customers values(" + cs.id + ",\"" + cs.imie + "\");");
        }
        public static void updateCustomer(Customer cs)
        {
            AddQuerry("update customers set imie=\"" + cs.imie + "\" where id=" + cs.id + ";");
        }

        private static string CreateInsertQuerry(Dictionary<string, string> d, string TableName)
        {
            string querry = "insert into ";
            querry += TableName;
            querry += " (";
            foreach (var it in d)
            {
                querry += it.Key;
                querry += ",";
            }
            querry = querry.Remove(querry.Length - 1, 1);
            querry += ") values (";
            foreach (var it in d)
            {
                querry += "\"";
                querry += it.Value;
                querry += "\"";
                querry += ",";

            }
            querry = querry.Remove(querry.Length - 1, 1);
            querry += ")";
            return querry;
        }

        private static string CreateUpdateQuerry(Dictionary<string, string> d, string TableName, uint id)
        {
            string querry = "update ";
            querry += TableName;
            querry += " set ";
            foreach (var it in d)
            {
                querry += it.Key;
                querry += ",";
            }
            querry = querry.Remove(querry.Length - 1, 1);
            querry += ") values (";
            foreach (var it in d)
            {
                querry += "\"";
                querry += it.Value;
                querry += "\"";
                querry += ",";

            }
            querry = querry.Remove(querry.Length - 1, 1);
            querry += ")";
            return querry;
        }
    }
    }


