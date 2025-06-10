using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //People p = new People("bb","zz", 5, "reporter");
            //Console.WriteLine(p);
            Report r = new Report();
            //r.AddPeople(p);
            // r.RequestingDataFromDatabase("SELECT  `first_name`, `last_name` FROM `people` WHERE `id`=1");
            r.InsertMessage();
        
        }
    }
}
