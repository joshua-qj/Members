using Members.CoreBusiness;

namespace Members.UseCases.TeamUsecases {
    public interface IDeleteTeamUseCase {
        Task ExecuteAsync(Team team);
    }
}