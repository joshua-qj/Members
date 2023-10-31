using Members.CoreBusiness;

namespace Members.UseCases.Interfaces
{
    public interface IDeleteTeamUseCase
    {
        Task ExecuteAsync(Team team);
    }
}