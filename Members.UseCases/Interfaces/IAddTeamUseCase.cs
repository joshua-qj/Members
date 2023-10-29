using Members.CoreBusiness;

namespace Members.UseCases.Interfaces
{
    public interface IAddTeamUseCase
    {
        Task ExecuteAsynce(Team team);
    }
}