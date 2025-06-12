using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.Dal
{
    internal class PeopleDal
    {

        IntelReportDal _IntelReportDal = new IntelReportDal();


        public void AddPeople(People people)
        {
            try
            {
                _IntelReportDal.openConnection();

                string query = $@"
            INSERT INTO `people` 
            (first_name, last_name,  secret_code)
            VALUES 
            (@first_name, @last_name,  @secret_code)";

                using (var cmd = new MySqlCommand(query, _IntelReportDal._conn))
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

        public int GetPeopleID(string firstName)
        {
            string query = $"SELECT `id`  FROM `people` WHERE `first_name`=@FirstName";
            int id = -1;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                _IntelReportDal.openConnection();
                cmd = new MySqlCommand(query, _IntelReportDal._conn);
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
                _IntelReportDal.closeConnection();
            }
            return id;
        }
        public void UpdatedNumReports(int id)
        {
            string query = "UPDATE `people` SET `num_reports` = `num_reports` + 1 WHERE `id` = @id";

            MySqlCommand cmd = null;
            try
            {
                _IntelReportDal.openConnection();
                cmd = new MySqlCommand(query, _IntelReportDal._conn);
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
                _IntelReportDal.closeConnection();
            }
        }
        public void UpdatedNumMentions(int id)
        {
            string query = "UPDATE `people` SET `num_mentions` = `num_mentions` + 1 WHERE `id` = @id";

            MySqlCommand cmd = null;
            try
            {
                _IntelReportDal.openConnection();
                cmd = new MySqlCommand(query, _IntelReportDal._conn);
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
                _IntelReportDal.closeConnection();
            }
        }
        public int GetNumReports(int id)
        {
            string query = "SELECT  num_reports FROM people WHERE id =  @id";
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            //int count_reporter_ID;
            int num_reports = 0;

            try
            {
                _IntelReportDal.openConnection();
                cmd = new MySqlCommand(query, _IntelReportDal._conn);
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
                _IntelReportDal.closeConnection();
            }
            return num_reports;
        }
        public int GetNumMentions(int id)
        {
            string query = "SELECT  num_mentions FROM people WHERE id =  @id";
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            //int count_reporter_ID;
            int num_mentions = 0;

            try
            {
                _IntelReportDal.openConnection();
                cmd = new MySqlCommand(query, _IntelReportDal._conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                //Console.WriteLine("num mentions  updated successfully.");
                reader = cmd.ExecuteReader();

                if (reader.Read())
                    num_mentions = reader.GetInt32("num_mentions");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                //if (reader != null && !reader.IsClosed)
                //    reader.Close();
                _IntelReportDal.closeConnection();
            }
            return num_mentions;
        }

        public string GetPeopleTipe(int id)
        {
            string query = "SELECT  type_poeple FROM people WHERE id = @id";
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            //int count_reporter_ID;
            string type_poeple = "";
            //TODO: cheng to persontipe

            try
            {
                _IntelReportDal.openConnection();
                cmd = new MySqlCommand(query, _IntelReportDal._conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                //Console.WriteLine("num mentions  updated successfully.");
                reader = cmd.ExecuteReader();

                if (reader.Read())
                    type_poeple = reader.GetString("type_poeple");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                //if (reader != null && !reader.IsClosed)
                //    reader.Close();
                _IntelReportDal.closeConnection();
            }
            return type_poeple;
        }

        public void UpdatedTypePoeple(int id, PersonType potential_agent)
        {
            string query = $"UPDATE `people` SET `type_poeple` = '{potential_agent}' WHERE `id` = @id";

            MySqlCommand cmd = null;
            try
            {
                _IntelReportDal.openConnection();
                cmd = new MySqlCommand(query, _IntelReportDal._conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                //Console.WriteLine("type_poeple updated successfully.");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error updated type_poeple: " + ex.Message);
            }
            finally
            {
                //if (reader != null && !reader.IsClosed)
                //    reader.Close();
                _IntelReportDal.closeConnection();
            }
        }

   


    }
}
