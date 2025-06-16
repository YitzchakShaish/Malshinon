using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Dal;
using Malshinon.UI;

namespace Malshinon.Services
{
    internal class ReporterAnalysisService
    {
        public void TestingPotentialAgent(int id)
        {
            IntelReportDal _IntelReportDal = new IntelReportDal();
            PeopleDal _PeopleDal = new PeopleDal();
            if (_PeopleDal.GetNumReports(id) >= 10 & _IntelReportDal.GetAverageText(id) >= 100)
            { 
                _PeopleDal.UpdatedTypePoeple(id, PersonType.potential_agent);
                ConsoleDisplay.ChangeStatusPotentialAgent(_PeopleDal.GetPersonByID(id));
            }
        }
        public void TestingIsDangerous(int id)
        {
            IntelReportDal _IntelReportDal = new IntelReportDal();
            PeopleDal _PeopleDal = new PeopleDal();
            int mentions = _PeopleDal.GetNumMentions(id);
            if (mentions >= 20)
            {
                _IntelReportDal.UpdatedIsDangerous(id);
                ConsoleDisplay.IsDangerous(_PeopleDal.GetPersonByID(id));
            }
        }
        public void TestingUpdateBoth(int id)
        {
            PeopleDal _PeopleDal = new PeopleDal();

            if (_PeopleDal.GetNumMentions(id) >= 1 & (_PeopleDal.GetNumReports(id) >= 1))
            {
                _PeopleDal.UpdatedTypePoeple(id, PersonType.both);
            }

        }
    }
}
