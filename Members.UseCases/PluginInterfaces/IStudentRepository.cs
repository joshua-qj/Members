using Members.CoreBusiness;
using Members.UseCases.PluginInterfaces;
using Microsoft.Maui.ApplicationModel.Communication;
using SQLite;

namespace Members.UseCases.PluginInterfaces {
    public interface IStudentRepository {
        Task AddStudentAsync(Student student);
        Task DeleteStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<List<Student>> GetStudentsAsync(string filterText);
        Task UpdateStudent(int studentId, Student student);
        Task<Student> ViewStudentAsync(int studentId);
    }
}
