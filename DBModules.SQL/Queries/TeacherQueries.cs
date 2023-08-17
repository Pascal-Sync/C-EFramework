using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Queries
{
    public class TeacherQueries : ITeacherQueries
    {
        private readonly EFTestDbContext _dbContext;

        public TeacherQueries(EFTestDbContext dbContext)
        {
            _dbContext = dbContext; //dependency injection is implemented once you have instantiated an object of the EFTestContext..

        }
        public async Task<List<TeacherCreatedResults>> ListTeachers()
        {
            var teachList = await _dbContext.Teachers.Select(z => new TeacherCreatedResults
            {
                FullName=z.FullName,
                TeacherId=z.TeacherId,
                TscNumber=z.TscNumber,
            }).ToListAsync();

            return teachList;
        }
        public async Task<List<TeacherCreatedResults>> ListTeachers(int SubId)
        {
            var Results = await _dbContext.Students
                .Where(s => s.SubjectId == SubId) // Filter by subject
                .Select(s => new TeacherCreatedResults
                {
                    FullName = s.Name,
                })
                .ToListAsync();

            return Results;
        }
    }
}
