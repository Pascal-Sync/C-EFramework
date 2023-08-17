﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class UpdateStudentRequest
    {
        public string? Name { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }

        public Guid SchoolId { get; set; }
    }
}
