using Members.CoreBusiness;

namespace Members.UseCases.Interfaces {
    public interface IViewStudentsUseCase {
        Task<List<Student>> ExecuteAsync(string filterText);
    }
}