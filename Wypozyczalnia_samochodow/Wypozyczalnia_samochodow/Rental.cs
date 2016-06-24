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

        public static Employee LoggedEmplyee;
  
        public static bool tryToLogIn(string login, string pass)
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
        public static List<Car> findCars(string brand, string model)
        {
            var list = new List<Car>();
            foreach (var it in cars)
            {
                if (it.availability && it.model.ToUpper().Contains(model.ToUpper()) && it.brand.ToUpper().Contains(brand.ToUpper()))
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
            // var conn = DBConnectionMySql.CreatConnection("wypozyczalnia","root","");
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
                if (it.id > id)
                    id = it.id;
            }
            return ++id;
        }
        public static void addCar(Car c)
        {
            cars.Add(c);
            DBConnectionMySql.addCar(c);
        }
        public static void updateCar(Car c)
        {

            DBConnectionMySql.updateCar(c);
        }
        public static void clearEverything()
        {
            cars.Clear();
            transactions.Clear();
        }
        public static bool isCarAvailaible(Car c)
        {
            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                if (transactions[i].car == c)
                {
                    return transactions[i].finished;
                }
            }
            return true;
        }

        public static List<Customer> findCustomer(string name, string last_name)
        {
            var list = new List<Customer>();
            foreach (var it in customers)
            {
                if (it.name.ToUpper().Contains(name.ToUpper()) && it.last_name.ToUpper().Contains(last_name.ToUpper()))
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
                if (it.id > id)
                    id = it.id;
            }
            return ++id;
        }
        public static void addCustomer(Customer cs)
        {
            customers.Add(cs);
            DBConnectionMySql.addCustomer(cs);
        }
        public static void updateCustomer(Customer cs)
        {
            DBConnectionMySql.updateCustomer(cs);
        }
        public static uint NewTransactionrId()
        {
            uint id = 0;
            foreach (var it in transactions)
            {
                if (it.id > id)
                    id = it.id;
            }
            return ++id;
        }
        public static Car findCar(uint id)
        {
            foreach (var it in cars)
            {
                if (it.id == id)
                    return it;
            }
            return null;
        }
        public static Customer findCustomer(uint id)
        {
            foreach (var it in customers)
            {
                if (it.id == id)
                    return it;
            }
            return null;
        }
        public static Car findCar(string number)
        {
            foreach (var it in cars)
            {
                if (it.registration.ToLower() == number.ToLower())
                    return it;
            }
            return null;
        }

        public static Transaction findTransaction(Car car)
        {
            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                if (transactions[i].car == car)
                {
                    if (!transactions[i].finished)
                        return transactions[i];
                    else
                        return null;
                }
            }
            return null;
        }
        public static Employee findEmployee(string login)
        {
            foreach (var it in employees)
            {
                if (it.login == login)
                    return it;
            }
            return null;
        }
        public static void addTransaction(Transaction t)
        {
            transactions.Add(t);
            DBConnectionMySql.addTransaction(t);
        }
        public static void updateTransaction(Transaction t)
        {

            DBConnectionMySql.updateTransaction(t);
        }

    }

}
