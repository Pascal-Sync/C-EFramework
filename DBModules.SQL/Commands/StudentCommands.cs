using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using DBModules.SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace DBModules.SQL.Commands
{
    public class StudentCommands : IStudentCommands
    {
        private readonly EFTestDbContext _dbContext;
        public StudentCommands(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<StudentCreatedResults> CreateStudent(CreateStudentRequest studentRequest)
        {
            Student student = new Student()
            {
                Address = studentRequest.Address,
                Dob = studentRequest.Dob,
                Name = studentRequest.Name,
                SchoolId = studentRequest.SchoolId
            };
            _dbContext.Students.Add(student);

            await _dbContext.SaveChangesAsync();

            StudentCreatedResults studentCreatedResults = new StudentCreatedResults() //why create an instance of StudentCreated results?
            {
                Age = (((DateTime.Now - student.Dob).Days) / 365),
                Name = student.Name,
                StudentID = student.StudentID
            };

            return studentCreatedResults;
        }
        public async Task DeleteStudent(Guid stuId)
        {
            // Step 1: Retrieve the student record from the database.
            var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentID == stuId);

            if (student != null)
            {
                // Step 2: Remove the student from the DbContext.
                _dbContext.Students.Remove(student);

                // Step 3: Save the changes to the database.
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task UpdateStudent(Guid stuId, UpdateStudentRequest updateRequest)
        {
            // Step 1: Retrieve the student record from the database.
            var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.StudentID == stuId);

            if (student != null)
            {
                // Step 2: Update student information in the DbContext.
                student.Name = updateRequest.Name;
                student.Address = updateRequest.Address;
                student.Dob = updateRequest.Dob;
                student.SchoolId = updateRequest.SchoolId;

                // Step 3: Save the changes to the database.
                await _dbContext.SaveChangesAsync();
            }
            
        }

        // Create rqeuest results for delete students and update students (shambamba)
        // Write Implementions for update and delete students following DBContext to update and delete
        // Create new commands for the other entities (School, subjects, streams, teachers)
        // Create query for student and other entities
    }

}
