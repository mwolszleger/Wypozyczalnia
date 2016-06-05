using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace Wypozyczalnia_samochodow
{
    static class DBConnectionMySql
    {
        public static string Server { get; set; }
        public static string User { get; set; }
        public static string Passwd { private get; set; }
        public static uint Port { get; set; }
        public static string FileName{get;set;}
        static DBConnectionMySql()
        {
            Server = "127.0.0.1";
            User = "root";
            Passwd = "";
            Port = 3306;

        }

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

        public static List<Car> SelectAllCars(MySqlConnection conn)
        {
            List<Car> cars = new List<Car>();
            string queryText = "SELECT id,model FROM auta";

            MySqlCommand command = new MySqlCommand(queryText, conn);

            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                var attributes = new Dictionary<string,string>();
                attributes.Add("model",dr[1].ToString());
                cars.Add(new Car (Convert.ToInt32(dr[0]),attributes));

            }
            dr.Close();
            return cars;

        }
        public static void AddQuerry(string s)
        {
            StreamWriter file = new StreamWriter("file.txt",true);
            file.WriteLine(s);
            file.Close();
        }
        public static void addCar(Car c)
        {
            AddQuerry("insert into cars values("+c.id+","+c.model+");");
        }

    }
}
