using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.TeamUsecases
{
    public class ViewTeamUseCase : IViewTeamUseCase {
        private readonly ITeamRepository _teamRepository;

        public ViewTeamUseCase(ITeamRepository teamRepository) {
            _teamRepository = teamRepository;
        }
        public async Task<Team> ExecuteAsync(int teamId) {
            return await _teamRepository.ViewTeamAsync(teamId);
        }
    }
}
