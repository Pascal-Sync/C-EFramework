﻿using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public interface IStudentCommands
    {
        Task<StudentCreatedResults> CreateStudent(CreateStudentRequest studentRequest);
        Task<StudentCreatedResults> DeleteStudent(CreateStudentRequest studentRequest);
        Task <StudentCreatedResults> UpdateStudent(CreateStudentRequest studentRequest);


    }
    
}
