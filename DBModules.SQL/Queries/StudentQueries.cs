using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore;

namespace DBModules.SQL.Queries
{
    public class StudentQueries : IStudentQueries
    {
        private readonly EFTestDbContext _dbContext;

        public StudentQueries(EFTestDbContext dbContext)
        {
            _dbContext = dbContext; //dependency injection is implemented once you have instantiated an object of the EFTestContext..
       
        }
        public async Task<List<StudentCreatedResults>> ListStudents()
        {
            var studentList = await _dbContext.Students.Select(s => new StudentCreatedResults
            {
                Age = s.Age,
                Name = s.Name,
                StudentID = s.StudentID,
            }).ToListAsync();

            return studentList;
        }
        public async Task<List<StudentCreatedResults>> ListStudents(int SubId)
        {
            var studentResults = await _dbContext.Students
                .Where(s => s.SubjectId == SubId) // Filter by subject
                .Select(s => new StudentCreatedResults
                {
                    Name = s.Name,
                })
                .ToListAsync();

            return studentResults;
        }

    }

}
