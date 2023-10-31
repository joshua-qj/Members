using Members.CoreBusiness;
using Members.UseCases.PluginInterfaces;
using Microsoft.Maui.ApplicationModel.Communication;
using SQLite;

namespace Members.UseCases.PluginInterfaces {
    public interface IStudentRepository {
        Task AddStudentAsync(Student student);
        Task DeleteStudentAsync(int studentId);
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<List<Student>> GetStudentsAsync(string filterText);
        Task UpdateStudent(int studentId, Student student);

    }
}
