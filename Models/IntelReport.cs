using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class IntelReport
    {
        public int id;
        public int reporter_id;
        public int target_id;
        public string text;
        public bool is_dangerous;
        public DateTime timestamp;

        public IntelReport(int reporter_id, int target_id, string text)
        {
            this.reporter_id = reporter_id;
            this.target_id = target_id;
            this.text = text;
        }
       
    }
}
