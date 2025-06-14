﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Malshinon.Dal;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;


namespace Malshinon
{
    internal class IntelSubmissionService
    {
        public int InsertName()
        {
            string first_name = "";
            string last_name = "";
            string forbidden_chars = "?!@#$%1234567890";

            while (first_name == "" || forbidden_chars.Contains(first_name[0]) || first_name.Length < 3)
            {
                Console.WriteLine("Enter your full name (first name is required): ");
                string input = Console.ReadLine();

                string[] pullName = input.Split(' ');
                if (pullName.Length >= 1)
                {
                    first_name = pullName[0];
                    if (pullName.Length >= 2)
                        last_name = pullName[1];
                }

                if (first_name == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must enter at least a first name.");
                    Console.ResetColor();
                }
            }

            //Console.WriteLine($"Hello, {first_name} {(string.IsNullOrWhiteSpace(last_name) ? "" : last_name)}!");

            PeopleDal _PeopleDal = new PeopleDal();

            int id = _PeopleDal.GetPeopleID(first_name);
            if (id == -1)
            {


                People newPeople = new People(first_name, last_name);
                newPeople.CreateSecretCode(first_name);
                _PeopleDal.AddPeople(newPeople);

                id = _PeopleDal.GetPeopleID(first_name);
                Console.WriteLine("A new people has been created successfully.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {id}");
            }
            else
            {
                id = _PeopleDal.GetPeopleID(first_name);

                Console.WriteLine("The people is already in the database.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {id}");

            }
            return id;

        }

        public Dictionary<int, string> InsertMessage()
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
            int id = _PeopleDal.GetPeopleID(first_name);
            if (id == -1)
            {
                People newPeople = new People(first_name, last_name);
                newPeople.CreateSecretCode(first_name);
                _PeopleDal.AddPeople(newPeople);
                id = _PeopleDal.GetPeopleID(first_name);
                Console.WriteLine("A new people has been created successfully.");
                Console.WriteLine($"Your first name is:{first_name} Your ID is: {id}");
            }
            else
            {
                id = _PeopleDal.GetPeopleID(first_name);

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
            IntelReportDal rd = new IntelReportDal();


            var pair = dictMessage.First();
            int target_id = pair.Key;
            string text = pair.Value;

            IntelReport newIntelReport = new IntelReport(reporter_id, target_id, text);
            rd.AddIntelReport(newIntelReport);
        }


    }
}
