using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Dal;
using Malshinon.Services;
using Malshinon.UI;


namespace Malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            IntelSubmissionService r = new IntelSubmissionService();
            PeopleDal _PeopleDal = new PeopleDal();
            IntelReportDal _IntelReportDal = new IntelReportDal();
            //r.SubmitIntelReport();
            //Person p = _PeopleDal.GetPersonByID(12);
            //Console.WriteLine(p);
            MainMenu mm = new MainMenu();

            mm.Show();
            //Console.WriteLine(_PeopleDal.GetPeopleID("BBB")); ;

        }
    }
}
