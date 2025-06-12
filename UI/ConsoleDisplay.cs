using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.UI
{
    static class ConsoleDisplay
    {
        public static void PeopleCreatedSuccessfully(People people)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A new people has been created successfully.");
            Console.WriteLine($"Your first name is:{people.first_name} Your ID is: {people.id}");
            Console.ResetColor();

        }
        public static void IntelReportCreatedSuccessfully(IntelReport intelReport)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("A new intelReport has been created successfully.");
            Console.WriteLine($"Your target ID is:{intelReport.target_id} Your massage is: {intelReport.text}");
            Console.ResetColor();
        }
        public static void ChangeStatusPotentialAgent(People people)
        {
            
            Console.WriteLine($"The man named:{people.first_name} defined as: {people.type_poeple} has {people.num_reports} reports on him.");
        }
        public static void IsDangerous(People people)
        {

            Console.WriteLine($"This terrorist { people.first_name} is very dangerous, there are {people.num_mentions} reports on him.");
        }
    }
}
