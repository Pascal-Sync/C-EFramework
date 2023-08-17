using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    public class StudentUpdatedResults
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Guid StudentID { get; set; }
    }
}
