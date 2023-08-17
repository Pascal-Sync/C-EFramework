using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public class TeacherCommands : ITeacherCommands
    {
        private readonly EFTestDbContext _dbContext;
        public TeacherCommands(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TeacherCreatedResults> CreateTeacher(CreateTeacherRequest teacherRequest)
        {
            Teacher teacher = new Teacher()
            {
                FullName = teacherRequest.FullName,
                TscNumber = teacherRequest.TscNumber,
                SchoolId = teacherRequest.SchoolId,
                Title = teacherRequest.Title
            };
            _dbContext.Teachers.Add(teacher);

            await _dbContext.SaveChangesAsync();

            TeacherCreatedResults teacherCreatedResults = new TeacherCreatedResults() //why create an instance of teacherCreated results?
            {
                FullName = teacher.FullName,
                TeacherId = teacher.TeacherId,
                TscNumber = teacher.TscNumber,
            };

            return teacherCreatedResults;
        }
        //public async Task<TeacherDeletedResults> DeleteTeacher(DeleteTeacherRequest deleteTeacher, int TeachId,)
        //{
        //    // Step 1: Retrieve the teacher record from the database.
        //    var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(s => s.TscNumber == TeachId);

        //    if (teacher == null)
        //    {
        //        throw new NullReferenceException("the Teacher Id can't be null");
        //    }
        //    else
        //    {
        //        // Step 2: Remove the teacher from the DbContext.
        //        _dbContext.Teachers.Remove(teacher);

        //        // Step 3: Save the changes to the database.
        //        await _dbContext.SaveChangesAsync();
        //    }

        //    TeacherDeletedResults deleteTeacherResults = new TeacherDeletedResults()
        //    {
        //        FullName = teacher.FullName,
        //        TeacherId = teacher.TeacherId,
        //        TscNumber = teacher.TscNumber,
        //    };
        //    return deleteTeacherResults;

        //}


        //public async Task<TeacherUpdatedResults> UpdateTeacher(Guid teachId, UpdateTeacherRequest updateRequest)
        //{
        //    // Step 1: Retrieve the teacher record from the database.
        //    var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(s => s.TeacherId == teachId);

        //    if (teacher == null)
        //    {
        //        throw new NullReferenceException("Teacher Id can't be null");
        //    }
        //    else
        //    {
        //        // Step 2: Update teacher information in the DbContext.
        //        teacher.FullName = updateRequest.FullName;
        //        teacher.TscNumber = updateRequest.TscNumber;
        //        teacher.SchoolId = updateRequest.SchoolId;

        //        // Step 3: Save the changes to the database.
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    TeacherUpdatedResults updateTeacherResults = new TeacherUpdatedResults()
        //    {
        //        FullName = teacher.FullName,
        //        TeacherId = teacher.TeacherId,
        //        TscNumber = teacher.TscNumber,
        //    };
        //    return updateTeacherResults;


        //}

        public async Task<TeacherDeletedResults> DeleteTeacher(DeleteTeacherRequest deleteRequest)
         {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(s => s.TeacherId == deleteRequest.TeacherId);

            if (teacher == null)
            {
                throw new NullReferenceException("the Teacher Id can't be null");
            }
            else
            {
                // Step 2: Remove the teacher from the DbContext.
                _dbContext.Teachers.Remove(teacher);

                // Step 3: Save the changes to the database.
                await _dbContext.SaveChangesAsync();
            }

            TeacherDeletedResults deleteTeacherResults = new TeacherDeletedResults()
            {
               // FullName = teacher.FullName,
                TeacherId = teacher.TeacherId
               // TscNumber = teacher.TscNumber,
            };
            return deleteTeacherResults;

        }

        public async Task<TeacherUpdatedResults> UpdateTeacher(UpdateTeacherRequest updateRequest)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(s => s.TeacherId == updateRequest.TeacherId);

            if (teacher == null)
            {
                throw new NullReferenceException("Teacher Id can't be null");
            }
            else
            {
                // Step 2: Update teacher information in the DbContext.
                teacher.FullName = updateRequest.FullName;
                teacher.TscNumber = updateRequest.TscNumber;
               // teacher.SchoolId = updateRequest.SchoolId;

                // Step 3: Save the changes to the database.
                await _dbContext.SaveChangesAsync();
            }
            TeacherUpdatedResults updateTeacherResults = new TeacherUpdatedResults()
            {
                FullName = teacher.FullName,
                TeacherId = teacher.TeacherId,
                TscNumber = teacher.TscNumber,
            };
            return updateTeacherResults;
        }
    }
    }
