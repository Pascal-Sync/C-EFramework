using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public interface ITeacherCommands
    {
        Task<TeacherCreatedResults> CreateTeacher(CreateTeacherRequest teacherRequest);
        Task<TeacherDeletedResults> DeleteTeacher (DeleteTeacherRequest deleteRequest);
        Task<TeacherUpdatedResults> UpdateTeacher(UpdateTeacherRequest updateRequest);
    }
}
