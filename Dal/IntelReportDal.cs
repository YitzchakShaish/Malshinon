using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Malshinon.Services;
using Malshinon.UI;



namespace Malshinon.Dal
{
    internal class IntelReportDal
    {

       
        public string connStr = "server=localhost;user=root;password=;database=malshinon";
        public MySqlConnection _conn;
        public MySqlConnection openConnection()
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connStr);
            }

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
                //Console.WriteLine("Connection successful.");
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
        public IntelReportDal()
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
   public void AddIntelReport(IntelReport intelReport)
        {
            PeopleDal _PeopleDal = new PeopleDal();
            ReporterAnalysisService _ReporterAnalysisService = new ReporterAnalysisService();

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
                _PeopleDal.UpdatedNumReports(intelReport.reporter_id);
                _PeopleDal.UpdatedNumMentions(intelReport.target_id);
                _PeopleDal.UpdatedTypePoeple(intelReport.target_id, PersonType.target);
                _ReporterAnalysisService.TestingPotentialAgent(intelReport.reporter_id);
                _ReporterAnalysisService.TestingIsDangerous(intelReport.target_id);
                _ReporterAnalysisService.TestingUpdateBoth(intelReport.reporter_id);
                _ReporterAnalysisService.TestingUpdateBoth(intelReport.target_id);
                ConsoleDisplay.IntelReportCreatedSuccessfully(intelReport);
                    }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting intel report row: " + ex.Message);
            }
        }
        public float GetAverageText(int reporter_id)
        {
            string query = "SELECT  AVG(LENGTH(text)) avg_text_report FROM intelreports WHERE reporter_ID =  @reporter_id";
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            //int count_reporter_ID;
            float avg_text_report = 0;

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
        public void UpdatedIsDangerous(int id)
        {
            string query = "UPDATE `intelreports` SET `is_dangerous`= True WHERE `target_id`= @id";

            MySqlCommand cmd = null;
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                //Console.WriteLine("type_poeple updated successfully.");

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error updated type_poeple: " + ex.Message);
            }
            finally
            {
                //if (reader != null && !reader.IsClosed)
                //    reader.Close();
                closeConnection();
            }
        }

        public void GetDangerousTerrorists()
        {
            string query = "SELECT DISTINCT p.first_name, p.last_name,p.num_mentions, i.is_dangerous FROM intelreports i JOIN people p ON i.target_id = p.id WHERE i.is_dangerous = 1;" ;
            MySqlDataReader reader = null;
            MySqlCommand cmd = null;
            string first_name;
            string last_name;
            int num_mentions;

            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);

                cmd.ExecuteNonQuery();
                //Console.WriteLine("num mentions  updated successfully.");
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    first_name = reader.GetString("first_name");
                    last_name = reader.GetString("last_name");
                    num_mentions = reader.GetInt32("num_mentions");
                    Console.WriteLine($"The name of the dangerous terrorist is:{first_name}, {last_name} The number of reports is: {num_mentions}");
                    Console.WriteLine();

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error updated type_poeple: " + ex.Message);
            }
            finally
            {
                //if (reader != null && !reader.IsClosed)
                //    reader.Close();
                closeConnection();
            }
        }

        //public  List<People> GetAllPotentialAgents() 
        //{
        //    string q = " SELECT MIN(timestamp) AS first_report_time, MAX(timestamp) AS last_report_time FROM intelreports i WHERE i.target_id = @id AND timestamp BETWEEN NOW() -INTERVAL 15 MINUTE AND NOW()  GROUP BY i.target_id HAVING COUNT(*) >= 3; ";
        //}
    }

}

