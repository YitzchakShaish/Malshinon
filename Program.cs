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
            ReporterAnalysisService r = new ReporterAnalysisService();
            //r.AddPeople(p);
            // r.RequestingDataFromDatabase("SELECT  `first_name`, `last_name` FROM `people` WHERE `id`=1");
            // r.InsertNameAndMessage();
            IntelReportDal rd = new IntelReportDal();
            //float f = rd.GetNumReports(11);
            //Console.WriteLine(f);
            //r.InsertNameAndMessage();
            // r.InsertNameAndMessage();
            rd.GetDangerousTerrorists();

        }
    }
}
