using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    public class TeacherCreatedResults
    {
        public Guid TeacherId { get; set; }
        public string? FullName { get; set; }
        public int TscNumber { get; set; }
    }
}
