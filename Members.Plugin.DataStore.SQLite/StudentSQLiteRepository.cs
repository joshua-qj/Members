using Members.CoreBusiness;
using Members.UseCases.PluginInterfaces;
using Microsoft.Maui.ApplicationModel.Communication;
using SQLite;

namespace Members.Plugin.DataStore.SQLite {
    public class StudentSQLiteRepository : IStudentRepository {


        private SQLiteAsyncConnection _database;

        public StudentSQLiteRepository()
        {

            _database = new SQLiteAsyncConnection(Constants.DatabasePath);
            _database.CreateTableAsync<Student>().Wait();
        }
        public async Task<List<Student>> GetStudentsAsync(string filterText) {
            if (string.IsNullOrWhiteSpace(filterText)) {
                // return await _database.Table<Student>().Include(s => s.Team)
                return await _database.Table<Student>()
        //return await _context.Students.Include(s => s.Team)
        .ToListAsync();
            }

            //return null;
            return await _database.QueryAsync<Student>(@"
                                    SELECT * 
                                    FROM Student 
                                    WHERE
                                        FirstName LIKE ? 
                                        LastName LIKE ? 
                                        Email LIKE ?  ",
                                $"%{filterText}%",
                                $"%{filterText}%",
                                $"%{filterText}%"
                      );
     
        }
        public async Task AddStudentAsync(Student student) {
           await _database.InsertAsync(student);
            //_context.Students.Add(student);
            //await _context.SaveChangesAsync();
        }


        public Task<Student> GetStudentByIdAsync(int studentId) {
            throw new NotImplementedException();
        }

      

        public async Task<Student> ViewTeamAsync(int studentId) {
             return await _database.Table<Student>().Where(t => t.StudentId == studentId).FirstOrDefaultAsync();
         //   throw new NotImplementedException();
        }

        public Task DeleteStudentAsync(Student student) {
            throw new NotImplementedException();
        }

        public Task UpdateStudent(int studentId, Student student) {
            throw new NotImplementedException();
        }

        public Task<Student> ViewStudentAsync(int studentId) {
            throw new NotImplementedException();
        }
    }
}
