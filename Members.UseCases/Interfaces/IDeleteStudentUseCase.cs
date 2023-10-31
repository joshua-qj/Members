using Members.CoreBusiness;

namespace Members.UseCases.Interfaces
{
    public interface IDeleteStudentUseCase
    {
        Task ExecuteAsync(int studentId);
    }
}