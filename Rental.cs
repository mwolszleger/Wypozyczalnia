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
        private static MySqlConnection conn;
        public static List<Car> findCars(string brand,string model)
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
                MessageBox.Show(myexc.Message);
            }
            finally
            {
                DBConnectionMySql.CloseConnection(conn);
            }
        }

    }

}
