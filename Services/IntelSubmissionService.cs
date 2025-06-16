using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Malshinon.Dal;
using Malshinon.UI;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;


namespace Malshinon
{
    internal class IntelSubmissionService
    {
        /// <summary>
        /// Requests the user's first and last name from the console, 
        /// checks if the person exists in the database, and creates a new record if not.
        /// </summary'[\
        /// <returns>The ID of the reporter (person).</returns>
        public int GetOrCreateReporter()
        {
            string first_name = "";
            string last_name = "";
            string forbidden_chars = "?!@#$%1234567890";

            while (first_name == "" || forbidden_chars.Contains(first_name[0]) || first_name.Length < 3)
            {
                Console.WriteLine("Enter your full name (first name is required): ");
                string input = Console.ReadLine();

                string[] nameParts = input.Split(' ');
                if (nameParts.Length >= 1)
                {
                    first_name = nameParts[0];
                    if (nameParts.Length >= 2)
                        last_name = nameParts[1];
                }

                if (first_name == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must enter at least a first name.");
                    Console.ResetColor();
                }
            }

            PeopleDal _PeopleDal = new PeopleDal();

            int id = _PeopleDal.GetPeopleIDByFirstName(first_name);
            if (id == -1)
            {
                Person newPerson = CreateNewPerson(first_name, last_name);
                id = _PeopleDal.GetPeopleIDByFirstName(first_name);

            }
            else
            {
                id = _PeopleDal.GetPeopleIDByFirstName(first_name);

                Console.WriteLine("The people is already in the database.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {id}");

            }
            return id;

        }

        public Dictionary<int, string> GetOrCreateTargetMessage()
        {
            string first_name = "";
            string last_name = "";
            Dictionary<int, string> dictMessage = new Dictionary<int, string>();
            string message = "";
            string forbidden_chars = "?!@#$%1234567890";

            while (first_name == "" || forbidden_chars.Contains(first_name[0]) || first_name.Length < 3)
            {
                Console.WriteLine("enter your message: ");
                message = Console.ReadLine();
                string[] arrMessage = message.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in arrMessage)
                {
                    if (!string.IsNullOrWhiteSpace(word) && char.IsUpper(word[0]) && first_name == "")
                    {
                        first_name = word;
                    }
                    else if (!string.IsNullOrWhiteSpace(word) && char.IsUpper(word[0]))
                    {
                        last_name = word;
                        break;
                    }
                }


                if (first_name == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You did not enter a name with a capital letter. Please enter your message again:");
                    Console.ResetColor();
                }
            }



            PeopleDal _PeopleDal = new PeopleDal();
            int id = _PeopleDal.GetPeopleIDByFirstName(first_name);
            if (id == -1)
            {
                Person newPerson = CreateNewPerson(first_name, last_name);
                id = _PeopleDal.GetPeopleIDByFirstName(first_name);
            }

            else
            {
                id = _PeopleDal.GetPeopleIDByFirstName(first_name);

                Console.WriteLine("The people is already in the database.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {id}");
            }
         
            dictMessage[id] = message;
            return dictMessage;
        }
        public void SubmitIntelReport()
        {
            int reporter_id = GetOrCreateReporter();
            Dictionary<int, string> dictMessage = GetOrCreateTargetMessage();
            IntelReportDal rd = new IntelReportDal();


            var pair = dictMessage.First();
            int target_id = pair.Key;
            string text = pair.Value;
            Console.WriteLine($"reporter_id: {reporter_id}, target_id: {target_id},  text: {text}");

            IntelReport newIntelReport = new IntelReport(reporter_id, target_id, text);
            rd.InsertNewIntelReport(newIntelReport);
        }

        private Person CreateNewPerson(string firstName, string lastName)
        {
            Person newPerson = new Person(firstName, lastName);
            newPerson.CreateSecretCode(firstName);

            PeopleDal _peopleDal = new PeopleDal();
            _peopleDal.InsertPerson(newPerson);

            newPerson.id = _peopleDal.GetPeopleIDByFirstName(firstName);
            ConsoleDisplay.PeopleCreatedSuccessfully(newPerson);

            return newPerson;
        }

    }
}
