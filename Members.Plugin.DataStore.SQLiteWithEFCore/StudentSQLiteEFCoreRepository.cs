using Members.CoreBusiness;
using Members.Plugin.DataStore.SQLiteWithEFCore;
using Members.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using SQLite;

namespace Members.Plugin.DataStore.SQLite {
    public class StudentSQLiteEFCoreRepository : IStudentRepository {
                private readonly ApplicationDbContext _context;

        public StudentSQLiteEFCoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetStudentsAsync(string filterText) {
            if (string.IsNullOrWhiteSpace(filterText)) {
                return await _context.Students.Include(s => s.Team)
                .ToListAsync();
            }

            return await _context.Students
        .Where(e => e.FirstName.Contains(filterText)|| e.LastName.Contains(filterText))
        .ToListAsync(); ;
            //return await _database.QueryAsync<Student>(@"
            //                        SELECT * 
            //                        FROM Student 
            //                        WHERE
            //                            FirstName LIKE ? 
            //                            LastName LIKE ? 
            //                            Email LIKE ?  ",
            //                    $"%{filterText}%",
            //                    $"%{filterText}%",
            //                    $"%{filterText}%"
            //          );

        }
        public async Task AddStudentAsync(Student student) {
            if (student is not null) {
               await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }
            return;
        }


        public async Task<Student> GetStudentByIdAsync(int studentId) {
            var student=await _context.Students.Where(t => t.StudentId == studentId).Include(s => s.Team).FirstOrDefaultAsync();
            if (student is not null) {
                return student;
            }
            return new Student();
        }

      

        public async Task<Student> ViewStudentAsync(int studentId) {
            if (studentId > 0) {
                var student= await _context.Students.Where(t => t.StudentId == studentId).FirstOrDefaultAsync();
                if (student != null) {
                    return student;
                }
            }
            return new Student();
        }



        public async Task UpdateStudent(int studentId, Student student) {
            if (studentId != student.StudentId) { return; }
            var studentToUpdate = await _context.Students.FindAsync(studentId);
            if (studentToUpdate is not null) {
                studentToUpdate.FirstName = student.LastName;
                studentToUpdate.LastName = student.FirstName;
                studentToUpdate.PhoneNumber = student.PhoneNumber;
                studentToUpdate.Email = student.Email;
                studentToUpdate.TeamId= student.TeamId; 
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteStudentAsync(int studentId) {
            var student = await GetStudentByIdAsync(studentId);
            if (student != null && student.StudentId == studentId) {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
