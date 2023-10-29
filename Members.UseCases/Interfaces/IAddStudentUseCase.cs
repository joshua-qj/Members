using Members.CoreBusiness;

namespace Members.UseCases.Interfaces
{
    public interface IAddStudentUseCase
    {
        Task ExecuteAsync(Student student);
    }
}