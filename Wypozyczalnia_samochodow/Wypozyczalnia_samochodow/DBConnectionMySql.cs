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
        
        public static uint Port { get; set; }
        public static string FileName { get; set; }
        static DBConnectionMySql()
        {
            Server = "127.0.0.1";
           // User = "root";
           // Passwd = "";
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

        //nazwa tabeli z klientami
        private static readonly string CustomersTableName = "customers";
        //nazwy kolum w tabeli z autami
        private static readonly string CustomersIdColumnName = "id";
        private static readonly string NameColumnName = "name";
        private static readonly string LastNameColumnName = "last_name";
        private static readonly string StreetColumnName = "street";
        private static readonly string HouseNumberColumnName = "house_number";
        private static readonly string FlatNumberColumnName = "flat_number";
        private static readonly string CodeTownColumnName = "code_town";
        private static readonly string PlaceColumnName = "place";
        private static readonly string PhoneNumberColumnName = "phone_number";

        //nazwa tabeli z transakcjanmi
        private static readonly string TransactionsTableName = "transactions";
        //nazwy kolum w tabeli z transakcjami
        private static readonly string TransactionIdColumnName = "id";
        private static readonly string TranscationCarIdColumnName = "id_car";
        private static readonly string TransactionCustomerIdColumnName = "id_customer";
        private static readonly string BeginningDateColumnName = "beginning_date";
        private static readonly string EndDateColumnName = "end_date";
        private static readonly string EmployeeBeginningColumnName = "employee_beginning";
        private static readonly string EmployeeEndTableName = "employee_end";
        private static readonly string EmployeePriceColumnName = "price";


        private static readonly string EmployeesTableName = "employees";
        private static readonly string LoginColumnName = "login";
        private static readonly string NameEmployeeColumnName = "name";
        private static readonly string LastNameEmployeeColumnName = "last_name";
        public static MySqlConnection CreatConnection(string DataBaseName, string User, string Passwd)
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
        private static void AddQuerry(string s)
        {
            StreamWriter file = new StreamWriter("file.txt", true);
            file.WriteLine(s);
            file.Close();
        }
        public static void AddCar(Car c)
        {
            var attributes = new Dictionary<string, string>();
            attributes.Add(CarIdColumnName, c.Brand);
            attributes.Add(BrandColumnName, c.Brand);
            attributes.Add(ModelColumnName, c.Model);
            attributes.Add(YearColumnName, c.Year.ToString());
            attributes.Add(EngineColumnName, c.Engine.ToString().Replace(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0], '.'));
            attributes.Add(ClimatisationColumnName, c.Climatisation.ToString());
            attributes.Add(FuelColumnName, c.Fuel.ToString());
            attributes.Add(ColorColumnName, c.Color);
            attributes.Add(RegistrationColumnName, c.Registration);
            attributes.Add(PriceColumnName, c.Price.ToString().Replace(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0], '.'));
            attributes.Add(CarAvailabilityColumnName, c.Availability.ToString());

            AddQuerry(CreateInsertQuerry(attributes, CarsTableName));
        }
        public static void UpdateCar(Car c)
        {
            var attributes = new Dictionary<string, string>();
            attributes.Add(BrandColumnName, c.Brand);
            attributes.Add(ModelColumnName, c.Model);
            attributes.Add(YearColumnName, c.Year.ToString());
            attributes.Add(EngineColumnName, c.Engine.ToString().Replace(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0], '.'));
            attributes.Add(ClimatisationColumnName, c.Climatisation.ToString());
            attributes.Add(FuelColumnName, c.Fuel.ToString());
            attributes.Add(ColorColumnName, c.Color);
            attributes.Add(RegistrationColumnName, c.Registration);
            attributes.Add(PriceColumnName, c.Price.ToString().Replace(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0], '.'));
            attributes.Add(CarAvailabilityColumnName, c.Availability.ToString());

            AddQuerry(CreateUpdateQuerry(attributes, CarsTableName, c.Id));
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

        private static string CreateUpdateQuerry(Dictionary<string, string> d, string TableName, object key, string keyName = "id")
        {
            string querry = "update ";
            querry += TableName;
            querry += " set ";
            foreach (var it in d)
            {
                querry += it.Key;
                querry += " = \"";
                querry += it.Value;
                querry += "\",";
            }
            querry = querry.Remove(querry.Length - 1, 1);
            querry += " where ";
            querry += keyName;
            querry += " = ";
            querry += key;
            querry += ";";
            return querry;
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
            string[] tableNames = new string[] { CustomersIdColumnName, NameColumnName, LastNameColumnName, StreetColumnName, HouseNumberColumnName, FlatNumberColumnName, CodeTownColumnName, PlaceColumnName, PhoneNumberColumnName };
            string queryText = CreateSelectQuerry(tableNames, CustomersTableName);
            MySqlCommand command = new MySqlCommand(queryText, conn);

            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                var attributes = new Dictionary<string, string>();
                attributes.Add("name", dr[1].ToString());
                attributes.Add("last_name", dr[2].ToString());
                attributes.Add("street", dr[3].ToString());
                attributes.Add("house_number", dr[4].ToString());
                if (FlatNumberColumnName != "")
                {
                    attributes.Add("flat_number", dr[5].ToString());
                }
                attributes.Add("code_town", dr[6].ToString());
                attributes.Add("place", dr[7].ToString());
                attributes.Add("phone_number", dr[8].ToString());
                customer.Add(new Customer(Convert.ToUInt32(dr[0]), attributes));

            }
            dr.Close();
            return customer;

        }
        public static void addCustomer(Customer c)
        {
            var attributes = new Dictionary<string, string>();
            attributes.Add(CustomersIdColumnName, c.Name);
            attributes.Add(NameColumnName, c.Name);
            attributes.Add(LastNameColumnName, c.Last_name);
            attributes.Add(StreetColumnName, c.Street);
            attributes.Add(HouseNumberColumnName, c.House_number.ToString());
            if (FlatNumberColumnName != "")
            {
                attributes.Add(FlatNumberColumnName, c.Flat_number.ToString());
            }
            attributes.Add(CodeTownColumnName, c.Code_town.ToString());
            attributes.Add(PlaceColumnName, c.Place);
            attributes.Add(PhoneNumberColumnName, c.Phone_number.ToString());

            AddQuerry(CreateInsertQuerry(attributes, CustomersTableName));
        }
        public static void updateCustomer(Customer c)
        {
            var attributes = new Dictionary<string, string>();
            attributes.Add(CustomersIdColumnName, c.Id.ToString());
            attributes.Add(NameColumnName, c.Name);
            attributes.Add(LastNameColumnName, c.Last_name);
            attributes.Add(StreetColumnName, c.Street);
            attributes.Add(HouseNumberColumnName, c.House_number.ToString());
            if (FlatNumberColumnName != "")
            {
                attributes.Add(FlatNumberColumnName, c.Flat_number.ToString());
            }
            attributes.Add(CodeTownColumnName, c.Code_town.ToString());
            attributes.Add(PlaceColumnName, c.Place);
            attributes.Add(PhoneNumberColumnName, c.Phone_number.ToString());

            AddQuerry(CreateUpdateQuerry(attributes, CustomersTableName, c.Id));
        }

        public static List<Employee> SelectAllEmployees(MySqlConnection conn)
        {
            List<Employee> emp = new List<Employee>();
            string[] tableNames = new string[] { LoginColumnName, NameEmployeeColumnName, LastNameEmployeeColumnName };
            string queryText = CreateSelectQuerry(tableNames, EmployeesTableName);
            MySqlCommand command = new MySqlCommand(queryText, conn);

            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {

                emp.Add(new Employee(dr[0].ToString(), dr[1].ToString(), dr[2].ToString()));

            }
            dr.Close();
            return emp;
        }
        public static void addTransaction(Transaction t)
        {
            var attributes = new Dictionary<string, string>();
            attributes.Add(TransactionIdColumnName, t.Id.ToString());
            attributes.Add(TranscationCarIdColumnName, t.Car.Id.ToString());
            attributes.Add(TransactionCustomerIdColumnName, t.Customer.Id.ToString());
            attributes.Add(EmployeeBeginningColumnName, t.Employee_beginning.Login);
            attributes.Add(BeginningDateColumnName, t.Beginning.ToString("yyyy-MM-dd"));
            AddQuerry(CreateInsertQuerry(attributes, TransactionsTableName));
        }

        public static List<Transaction> SelectAllTransactions(MySqlConnection conn)
        {
            var transactions = new List<Transaction>();
            string[] tableNames = new string[] { TransactionIdColumnName, TranscationCarIdColumnName, TransactionCustomerIdColumnName, BeginningDateColumnName, EndDateColumnName, EmployeeBeginningColumnName, EmployeeEndTableName, EmployeePriceColumnName };
            string queryText = CreateSelectQuerry(tableNames, TransactionsTableName);
            MySqlCommand command = new MySqlCommand(queryText, conn);
            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                var attributes = new Dictionary<string, string>();
                attributes.Add("id", dr[0].ToString());
                attributes.Add("car", dr[1].ToString());
                attributes.Add("customer", dr[2].ToString());
                attributes.Add("beginning", dr[3].ToString());
                attributes.Add("end", dr[4].ToString());
                attributes.Add("employee_beginning", dr[5].ToString());
               attributes.Add("employee_end", dr[6].ToString());
                
                attributes.Add("price", dr[7].ToString().Replace('.', CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0]));

                transactions.Add(new Transaction(attributes));

            }
            dr.Close();
            return transactions;
        }
        public static void updateTransaction(Transaction t)
        {
            var attributes = new Dictionary<string, string>();
            attributes.Add(EmployeeEndTableName, t.Employee_end.Login);
            attributes.Add(EndDateColumnName, t.End.ToString("yyyy-MM-dd"));
    
            attributes.Add(EmployeePriceColumnName, t.Price.ToString().Replace(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0], '.'));
            AddQuerry(CreateUpdateQuerry(attributes, TransactionsTableName,t.Id));
        }
    }
}
