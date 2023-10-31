using Members.CoreBusiness;

namespace Members.UseCases.Interfaces
{
    public interface IEditStudentUseCase
    {
        Task ExecuteAsync(int studentId, Student student);
    }
}