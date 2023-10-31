using Members.CoreBusiness;

namespace Members.UseCases.Interfaces {
    public interface IEditTeamUseCase {
        Task ExecuteAsync(int teamId, Team team);
    }
}