using Members.CoreBusiness;

namespace Members.UseCases.TeamUseCases {
    public interface IEditTeamUseCase {
        Task ExecuteAsync(int teamId, Team team);
    }
}