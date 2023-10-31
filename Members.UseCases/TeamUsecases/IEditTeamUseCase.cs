using Members.CoreBusiness;

namespace Members.UseCases.TeamUsecases {
    public interface IEditTeamUseCase {
        Task ExecuteAsync(int teamId, Team team);
    }
}