using Members.CoreBusiness;

namespace Members.UseCases.Interfaces
{
    public interface IViewStudentUseCase
    {
        Task<Student> ExecuteAsync(int studentId);
    }
}