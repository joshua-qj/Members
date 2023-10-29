using Members.CoreBusiness;

namespace Members.UseCases.Interfaces
{
    public interface IViewTeamsUseCase
    {
        Task<List<Team>> ExecuteAsync(string filterText);
    }
}