using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Malshinon
{
    internal class ReportDal
    {
        public string connStr = "server=localhost;user=root;password=;database=malshinon";
        private MySqlConnection _conn;
        public MySqlConnection openConnection()
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connStr);
            }

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
                Console.WriteLine("Connection successful.");
            }

            return _conn;
        }

        public void closeConnection()
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
                _conn = null;
            }
        }
        public ReportDal()
        {
            try
            {
                openConnection();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }
        public void AddPeople(People people)
        {
            try
            {
                openConnection();

                string query = $@"
            INSERT INTO `people` 
            (first_name, last_name,  secret_code)
            VALUES 
            (@first_name, @last_name,  @secret_code)";

                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@first_name", people.first_name);
                    cmd.Parameters.AddWithValue("@last_name", people.last_name);
                    cmd.Parameters.AddWithValue("@secret_code", people.secret_code);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Row inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting row: " + ex.Message);
            }
        }
        public void AddPeople2(People people)
        {
            try
            {
                openConnection();

                string query = $@"
            INSERT INTO `people` 
            (first_name, last_name)
            VALUES 
            (@first_name, @last_name)";

                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@first_name", people.first_name);
                    cmd.Parameters.AddWithValue("@last_name", people.last_name);


                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Row inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting row: " + ex.Message);
            }
        }
        public int RequestingIDFromPeopleTable(string firstName)
        {
            string query = $"SELECT `id`  FROM `people` WHERE `first_name`=@FirstName";
            int id = -1;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                    id = reader.GetInt32("id");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: Data not received. " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                closeConnection();
            }
            return id;
        }

        public void InsertName()
        {
            Console.WriteLine("enter your fool name; ");
            string[] foolName = Console.ReadLine().Split();
            string first_name = foolName[0];
            string last_name = foolName[1];
            //Console.WriteLine($"firstname: {first_name}, lastname: {last_name}");
          
            int id = RequestingIDFromPeopleTable(first_name);
            if ( id == -1)
            {
                Random rnd = new Random();
                string secret_code = GenretrRandom.GenerateCode(8);
                Console.WriteLine("secret_code=: " + secret_code);

                People newP = new People(first_name, last_name, secret_code);
                AddPeople(newP);
                Console.WriteLine("A new people has been created successfully.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {RequestingIDFromPeopleTable(first_name)}"); 
            }
            else
            {
                Console.WriteLine("The people is already in the database.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {RequestingIDFromPeopleTable(first_name)}");

            }
        }
    }
}
