﻿using MySql.Data.MySqlClient;
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
        private static List<Customer> customer = new List<Customer>();
        private static List<Transaction> transactions = new List<Transaction>();
        private static MySqlConnection conn;

       

        //zwraca listę referencji do aut spełniających kryteria wyszukiwania
        public static List<Car> findCars(string brand, string model)
        {
            var list = new List<Car>();
            foreach (var it in cars)
            {
                if (it.availability&&it.model.ToUpper().Contains(model.ToUpper())&& it.brand.ToUpper().Contains(brand.ToUpper()))
                {
                    list.Add(it);
                }
            }
            return list;
        }
        public static void LoadCars()
        {
            conn = DBConnectionMySql.CreatConnection("wypozyczalnia");
            try
            {
                DBConnectionMySql.OpenConnection(conn);
                var cars = DBConnectionMySql.SelectAllCars(conn);
                foreach (var it in cars)
                {
                    Rental.cars.Add(it);
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
            var conn = DBConnectionMySql.CreatConnection("wypozyczalnia");
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
                    return transactions[i].isFinished();
                }
            }
            return true;
        }

        public static void LoadCustomer()
        {
            conn = DBConnectionMySql.CreatConnection("wypozyczalnia");
            try
            {
                DBConnectionMySql.OpenConnection(conn);
                var customer = DBConnectionMySql.SelectAllCustomers(conn);
                foreach (var it in customer)
                {
                    Rental.customer.Add(it);
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
        public static List<Customer> findCustomers(string name, string last_name)
        {
            var list = new List<Customer>();
            foreach (var it in customer)
            {
                if (it.name.Contains(name)&&it.last_name.Contains(last_name))
                {
                    list.Add(it);
                }
              
            }
            return list;
        }
        public static int NewCustomerId()
        {
            int id = 0;
            foreach (var it in customer)
            {
                if (it.id > id)
                    id = it.id;
            }
            return ++id;
        }
        public static void addCustomer(Customer cs)
        {
            customer.Add(cs);
            DBConnectionMySql.addCustomer(cs);
        }
        public static void updateCustomer(Customer cs)
        {
            DBConnectionMySql.updateCustomer(cs);
        }
    }

}
