using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Queries
{
    public interface ITeacherQueries
    {
        Task<List<TeacherCreatedResults>> ListStudents();
        Task<List<TeacherCreatedResults>> ListTeachers(int SubId);
        // Add more Queries that accept parameters to filter the list of students

    }
}
