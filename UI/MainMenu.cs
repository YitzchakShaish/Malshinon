using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Dal;

namespace Malshinon.UI
{
    internal class MainMenu
    {
        public  void Show()
        {
            IntelReportDal _intelReportDal = new IntelReportDal();
            PeopleDal _peopleDal = new PeopleDal();
            IntelSubmissionService _intelSubmissionService = new IntelSubmissionService();
            Console.Clear();
            Console.Title = "Intelligence Analysis Dashboard";
            Console.ForegroundColor = ConsoleColor.Cyan;

            PrintHeader("Intelligence Analysis Menu");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. View Potential Agents");
            Console.WriteLine("2. View Dangerous Targets");
            Console.WriteLine("3. Insert a new message");
            Console.WriteLine("0. Exit");

            Console.Write("Your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    _peopleDal.GetAllPotentialAgents();
                    break;
                case "2":
                    _intelReportDal.GetDangerousTerrorists();
                    break;
                case "3":
                    _intelSubmissionService.SubmitIntelReport();
                    break;
                case "0":
                    Console.WriteLine("\nExiting the analysis menu...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Press any key to try again...");
                    Console.ReadKey();
                    Show();
                    break;
            }
        }

        private static void PrintHeader(string title)
        {
            Console.WriteLine(new string('═', 50));
            Console.WriteLine($"            {title}");
            Console.WriteLine(new string('═', 50));
        }

     

        private  void ReturnToMenu()
        {
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            Show();
        }
    }


}

