using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    public class TeacherDeletedResults
    {
        public Guid TeacherId { get; set; }
        public string? FullName { get; set; }
        public int TscNumber { get; set; }
    };
}