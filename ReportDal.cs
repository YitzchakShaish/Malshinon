using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;


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
        public void AddIntelReport(IntelReport intelReport)
        {
            try
            {
                openConnection();

                string query = $@"
            INSERT INTO `intelreports` 
            ( reporter_id, target_id, text)
            VALUES 
            (@reporter_id, @target_id,  @text)";

                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@reporter_id", intelReport.reporter_id);
                    cmd.Parameters.AddWithValue("@target_id", intelReport.target_id);
                    cmd.Parameters.AddWithValue("@text", intelReport.text);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Row inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting intel report row: " + ex.Message);
            }
        }
        public void UpdatedNumReports(int id)
        {
            string query = "UPDATE `people` SET `num_reports` = `num_reports` + 1 WHERE `id` = @id";

            MySqlCommand cmd = null;
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("num mentions  updated successfully.");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error updated num mentions: " + ex.Message);
            }
            finally
            {
                //if (reader != null && !reader.IsClosed)
                //    reader.Close();
                closeConnection();
            } 
        }
        public void UpdatedNumMentions(int id)
        {
            string query = "UPDATE `people` SET `num_mentions` = `num_mentions` + 1 WHERE `id` = @id";

            MySqlCommand cmd = null;
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Num reports updated successfully.");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error updated num reports: " + ex.Message);
            }
            finally
            {
                //if (reader != null && !reader.IsClosed)
                //    reader.Close();
                closeConnection();
            }
        }

        public float GetAverageText(int reporter_id)
        {
            string query = "SELECT  AVG(LENGTH(text)) avg_text_report FROM intelreports WHERE reporter_ID =  @reporter_id";
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            //int count_reporter_ID;
            float avg_text_report= 0;

            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@reporter_id", reporter_id);
                cmd.ExecuteNonQuery();
                //Console.WriteLine("num mentions  updated successfully.");
                reader = cmd.ExecuteReader();

                if (reader.Read())
                    avg_text_report = reader.GetInt32("avg_text_report");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                //if (reader != null && !reader.IsClosed)
                //    reader.Close();
                closeConnection();
            }
            return avg_text_report;
            }
        public float GetNumReports(int id)
        {
            string query = "SELECT  num_reports FROM people WHERE id =  @id";
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            //int count_reporter_ID;
            int num_reports = 0;

            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                //Console.WriteLine("num mentions  updated successfully.");
                reader = cmd.ExecuteReader();

                if (reader.Read())
                    num_reports = reader.GetInt32("num_reports");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                //if (reader != null && !reader.IsClosed)
                //    reader.Close();
                closeConnection();
            }
            return num_reports;
        }

    }
}
