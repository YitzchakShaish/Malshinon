using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.UI
{
    static class ConsoleDisplay
    {
        public static void PeopleCreatedSuccessfully(Person person)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A new person has been created successfully.");
            Console.WriteLine($"Your first name is:{person.first_name} Your ID is: {person.id}");
            Console.ResetColor();

        }
        public static void IntelReportCreatedSuccessfully(IntelReport intelReport)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("A new intelReport has been created successfully.");
            Console.WriteLine($"Your target ID is:{intelReport.target_id} Your massage is: {intelReport.text}");
            Console.ResetColor();
        }
        public static void ChangeStatusPotentialAgent(Person person)
        {
            
            Console.WriteLine($"The man named:{person.first_name} defined as: {person.type_poeple} has {person.num_reports} reports on him.");
        }
        public static void IsDangerous(Person person)
        {

            Console.WriteLine($"This terrorist { person.first_name} is very dangerous, there are {person.num_mentions} reports on him.");
        }
        private static bool headerPrinted = false;

        public static void AllPotentialAgents(string firstName, int num_reports, float avg_text_length)
        {
            if (!headerPrinted)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(new string('═', 50));
                Console.WriteLine(String.Format("{0,-20} | {1,-15} | {2,-15}", "First Name", "Reports", "Avg. Length"));
                Console.WriteLine(new string('═', 50));
                headerPrinted = true;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("{0,-20} | {1,-15} | {2,-15:N1}", firstName, num_reports, avg_text_length));
            Console.ResetColor();
        }
        public static void AllDangerousTerrorists(string firstName, int num_mentions)
        {
            if (!headerPrinted)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(new string('═', 50));
                Console.WriteLine(String.Format("{0,-30} | {1,-15} ", "First Name", "num_mentions"));
                Console.WriteLine(new string('═', 50));
                headerPrinted = true;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("{0,-30} | {1,-15} ", firstName, num_mentions));
            Console.ResetColor();
        }

        public static void ResetHeader()
        {
            headerPrinted = false;
        }
    }
}
