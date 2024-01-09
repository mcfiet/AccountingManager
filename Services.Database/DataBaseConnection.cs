using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Database
{
    public class DataBaseConnection
    {
        string connectionString = "server=rdbms.strato.de;port=3306;user id=dbu5370690;database=dbs12456788;password=TestData123#;";
        private MySqlConnection connection;

        public DataBaseConnection()
        {
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString;
            //System.Data.SqlClient.SqlConnection cnn; // nicht für mySQL
            MySql.Data.MySqlClient.MySqlConnection cnn;


            //connectionString = tbConnectionString.Text.ToString();
            connectionString = @"server=localhost,3306;user id=testuser;password=testpassword;database=testdb"; // nicht für MySql.Data.MySqlClient.MySqlConnection
            connectionString = @"server=rdbms.strato.de;port=3306;user id=dbu5370690;password=TestData123#;database=dbs12456788";

            try
            {
                //cnn = new System.Data.SqlClient.SqlConnection(connectionString); // nicht für mySQL
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                Console.WriteLine("OPENOPENOPEN");
                cnn.Close();
            }
            catch (Exception except)
            {
                //throw;
            }
        }

        public string GetData()
        {
            using (MySqlCommand command = new MySqlCommand("SELECT * FROM clients", connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetString(0) ?? "";
                        // Verarbeiten Sie die Daten aus der Abfrage hier.
                    }
                }
            }
            return "No Data";
        }
    }
}
