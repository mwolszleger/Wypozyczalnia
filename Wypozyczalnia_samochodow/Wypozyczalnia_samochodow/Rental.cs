using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia_samochodow
{
    static class Rental
    {
        private static List<Car> cars = new List<Car>();
        private static List<Customer> customers = new List<Customer>();
        private static List<Transaction> transactions = new List<Transaction>();
        private static List<Employee> employees = new List<Employee>();
        private static MySqlConnection conn;

        public static Employee LoggedEmplyee { get; set; }
  
        public static bool TryToLogIn(string login, string pass)
        {
            bool success = true;
            try
            {
                conn = DBConnectionMySql.CreatConnection("wypozyczalnia", login, pass);
                DBConnectionMySql.OpenConnection(conn);
                DBConnectionMySql.CloseConnection(conn);
            }
            catch (Exception e)
            {
                success = false;
            }

            return success;
        }
        public static List<Car> FindCars(string brand, string model)
        {
            var list = new List<Car>();
            foreach (var it in cars)
            {
                if (it.Availability && it.Model.ToUpper().Contains(model.ToUpper()) && it.Brand.ToUpper().Contains(brand.ToUpper()))
                {
                    list.Add(it);
                }
            }
            return list;
        }
        public static void LoadFromDataBase()
        {

            try
            {
                DBConnectionMySql.OpenConnection(conn);
                var cars = DBConnectionMySql.SelectAllCars(conn);
                foreach (var it in cars)
                {
                    Rental.cars.Add(it);
                }
                var customer = DBConnectionMySql.SelectAllCustomers(conn);
                foreach (var it in customer)
                {
                    Rental.customers.Add(it);
                }
                
                var emp = DBConnectionMySql.SelectAllEmployees(conn);
                foreach (var it in emp)
                {
                    Rental.employees.Add(it);

                }
                var tr = DBConnectionMySql.SelectAllTransactions(conn);
                foreach (var it in tr)
                {
                    Rental.transactions.Add(it);
                    

                }

            }
            catch (MySqlException myexc)
            {
                throw myexc;
            }
            finally
            {
                DBConnectionMySql.CloseConnection(conn);
            }
        }
        public static void SaveToBase()
        {
            
            try
            {
                DBConnectionMySql.OpenConnection(conn);
                DBConnectionMySql.ExecuteQuerries(conn);

            }
            catch (MySqlException myexc)
            {
                throw (myexc);
            }
            finally
            {
                DBConnectionMySql.CloseConnection(conn);
            }
        }

        public static uint NewCarId()
        {
            uint id = 0;
            foreach (var it in cars)
            {
                if (it.Id > id)
                    id = it.Id;
            }
            return ++id;
        }
        public static void AddCar(Car c)
        {
            cars.Add(c);
            DBConnectionMySql.AddCar(c);
        }
        public static void UpdateCar(Car c)
        {

            DBConnectionMySql.UpdateCar(c);
        }
        public static void ClearEverything()
        {
            cars.Clear();
            transactions.Clear();
            customers.Clear();
            employees.Clear();
        }
        public static bool IsCarAvailaible(Car c)
        {
            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                if (transactions[i].Car == c)
                {
                    return transactions[i].Finished;
                }
            }
            return true;
        }

        public static List<Customer> FindCustomer(string name, string last_name)
        {
            var list = new List<Customer>();
            foreach (var it in customers)
            {
                if (it.Name.ToUpper().Contains(name.ToUpper()) && it.Last_name.ToUpper().Contains(last_name.ToUpper()))
                {
                    list.Add(it);
                }

            }
            return list;
        }
        public static uint NewCustomerId()
        {
            uint id = 0;
            foreach (var it in customers)
            {
                if (it.Id > id)
                    id = it.Id;
            }
            return ++id;
        }
        public static void AddCustomer(Customer cs)
        {
            customers.Add(cs);
            DBConnectionMySql.addCustomer(cs);
        }
        public static void UpdateCustomer(Customer cs)
        {
            DBConnectionMySql.updateCustomer(cs);
        }
        public static uint NewTransactionrId()
        {
            uint id = 0;
            foreach (var it in transactions)
            {
                if (it.Id > id)
                    id = it.Id;
            }
            return ++id;
        }
        public static Car FindCar(uint id)
        {
            foreach (var it in cars)
            {
                if (it.Id == id)
                    return it;
            }
            return null;
        }
        public static Customer FindCustomer(uint id)
        {
            foreach (var it in customers)
            {
                if (it.Id == id)
                    return it;
            }
            return null;
        }
        public static Car FindCar(string number)
        {
            foreach (var it in cars)
            {
                if (it.Registration.ToLower() == number.ToLower())
                    return it;
            }
            return null;
        }

        public static Transaction FindTransaction(Car car)
        {
            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                if (transactions[i].Car == car)
                {
                    if (!transactions[i].Finished)
                        return transactions[i];
                    else
                        return null;
                }
            }
            return null;
        }
        public static Employee FindEmployee(string login)
        {
            foreach (var it in employees)
            {
                if (it.Login == login)
                    return it;
            }
            return null;
        }
        public static void AddTransaction(Transaction t)
        {
            transactions.Add(t);
            DBConnectionMySql.addTransaction(t);
        }
        public static void UpdateTransaction(Transaction t)
        {

            DBConnectionMySql.updateTransaction(t);
        }
        public static bool ExistsRegistryNumber(string number)
        {
            foreach (var it in cars)
            {
                if (it.Registration == number&&it.Availability)
                    return true;                
            }
            return false;
        }
    }

}
