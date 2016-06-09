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
        private static List<Transaction> transactions = new List<Transaction>();
        private static MySqlConnection conn;

        public static List<Car> findCars(string brand, string model)
        {
            var list = new List<Car>();
            foreach (var it in cars)
            {
                if (it.model.Contains(model))
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

        public static int NewCarId()
        {
            int id = 0;
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


    }

}
