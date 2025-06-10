using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;


namespace Malshinon
{
    internal class Report
    {
        public int InsertName()
        {
            Console.WriteLine("enter your fool name; ");
            string[] foolName = Console.ReadLine().Split();
            string first_name = foolName[0];
            string last_name = foolName[1];
            //Console.WriteLine($"firstname: {first_name}, lastname: {last_name}");
            ReportDal rd = new ReportDal();

            int id = rd.RequestingIDFromPeopleTable(first_name);
            if (id == -1)
            {
                Random rnd = new Random();
                string secret_code = GenretrRandom.GenerateCode(8);
                Console.WriteLine("secret_code=: " + secret_code);

                People newP = new People(first_name, last_name, secret_code);
                rd.AddPeople(newP);
                id = rd.RequestingIDFromPeopleTable(first_name);
                Console.WriteLine("A new people has been created successfully.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {id}");
            }
            else
            {
                id = rd.RequestingIDFromPeopleTable(first_name);

                Console.WriteLine("The people is already in the database.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {id}");

            }
            return id;

        }

        public Dictionary<int, string> InsertMessage()
        {
            Console.WriteLine("enter your message; ");
            string message = Console.ReadLine();
            string[] arrMessage = message.Split(' ');
            string first_name = null;
            string last_name = null;
            Dictionary<int, string> dictMessage = new Dictionary<int, string>();
            foreach (string word in arrMessage)
            {
                if (char.IsUpper(word[0]) & first_name == null)
                { 
                    first_name = word;
                }
                else if (char.IsUpper(word[0]))
                { 
                    last_name = word;
                    break;
                }
            }
            Console.WriteLine($"firstname: {first_name}, lastname: {last_name}");
            ReportDal rd = new ReportDal();

            int id = rd.RequestingIDFromPeopleTable(first_name);
            if (id == -1)
            {
                Random rnd = new Random();
                string secret_code = GenretrRandom.GenerateCode(8);
                Console.WriteLine("secret_code=: " + secret_code);

                People newP = new People(first_name, last_name, secret_code);
                rd.AddPeople(newP);
                id = rd.RequestingIDFromPeopleTable(first_name);
                Console.WriteLine("A new people has been created successfully.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {id}");
            }
            else
            {
                id = rd.RequestingIDFromPeopleTable(first_name);

                Console.WriteLine("The people is already in the database.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {id}");
            }
            dictMessage[id] = message;
            return dictMessage;
        }
        public void InsertNameAndMessage()
        {
            int reporter_id = InsertName();
            Dictionary<int, string> dictMessage = InsertMessage();
            ReportDal rd = new ReportDal();

            int target_id = 0;
            string text ="";
            if (dictMessage.Count == 1)
            {
                var pair = dictMessage.First();
                target_id = pair.Key;
                text = pair.Value;
            }
            IntelReport newIntelReport = new IntelReport(reporter_id, target_id, text);
            rd.AddIntelReport(newIntelReport);
            rd.UpdatedNumReports(reporter_id);
            rd.UpdatedNumMentions(target_id);
    }
    }
}
