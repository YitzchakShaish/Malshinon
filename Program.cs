using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Dal;
using Malshinon.Services;


namespace Malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            IntelSubmissionService r = new IntelSubmissionService();
            PeopleDal _PeopleDal = new PeopleDal();
            IntelReportDal _IntelReportDal = new IntelReportDal();
            //r.InsertNameAndMessage();
            People p = _PeopleDal.GetPeopleByID(12);
            Console.WriteLine(p);

            //Console.WriteLine(_PeopleDal.GetPeopleID("BBB")); ;

        }
    }
}
