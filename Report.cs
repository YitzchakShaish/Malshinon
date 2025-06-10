using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Malshinon
{
    internal class Report
    {
        public void InsertName()
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
                Console.WriteLine("A new people has been created successfully.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {rd.RequestingIDFromPeopleTable(first_name)}");
            }
            else
            {
                Console.WriteLine("The people is already in the database.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {rd.RequestingIDFromPeopleTable(first_name)}");

            }
        }

        public void InsertMessage()
        {
            Console.WriteLine("enter your message; ");
            string[] message = Console.ReadLine().Split(' ');
            string first_name = null;
            string last_name = null;
            foreach (string word in message)
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
                Console.WriteLine("A new people has been created successfully.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {rd.RequestingIDFromPeopleTable(first_name)}");
            }
            else
            {
                Console.WriteLine("The people is already in the database.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {rd.RequestingIDFromPeopleTable(first_name)}");
            }
        }

    }
}
