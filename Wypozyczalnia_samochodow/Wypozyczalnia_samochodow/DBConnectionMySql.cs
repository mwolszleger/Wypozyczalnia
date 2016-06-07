using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

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
                var attributes = new Dictionary<string, string>();
                attributes.Add("model", dr[1].ToString());
                cars.Add(new Car(Convert.ToInt32(dr[0]), attributes));

            }
            dr.Close();
            return cars;

        }
        public static void AddQuerry(string s)
        {
            StreamWriter file = new StreamWriter("file.txt", true);
            file.WriteLine(s);
            file.Close();
        }
        public static void addCar(Car c)
        {
            AddQuerry("insert into auta values(" + c.id + ",\"" + c.model + "\");");
        }
        public static void updateCar(Car c)
        {
            AddQuerry("update auta set model=\""+c.model+"\" where id="+c.id+";");
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
      
    }
}
