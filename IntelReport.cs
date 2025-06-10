using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class IntelReport
    {
        int id;
        int reporter_id;
        int target_id;
        string text;
        DateTime timestamp;

        public IntelReport(int reporter_id, int target_id, string text)
        {
            this.reporter_id = reporter_id;
            this.target_id = target_id;
            this.text = text;
        }
    }
}
