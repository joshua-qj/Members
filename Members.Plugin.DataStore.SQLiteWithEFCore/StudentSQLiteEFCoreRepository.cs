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

        }


        public Task<Student> GetStudentByIdAsync(int studentId) {
            throw new NotImplementedException();
        }

      

        public async Task<Student> ViewTeamAsync(int studentId) {
           //  return await _database.Table<Student>().Where(t => t.StudentId == studentId).FirstOrDefaultAsync();
          throw new NotImplementedException();
        }
    }
}
