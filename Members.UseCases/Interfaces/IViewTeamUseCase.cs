using Members.CoreBusiness;

namespace Members.UseCases.Interfaces
{
    public interface IViewTeamUseCase
    {
        Task<Team> ExecuteAsync(int teamId);
    }
}