using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.TeamUseCases {
    public class ViewTeamsUseCase : IViewTeamsUseCase {
        private readonly ITeamRepository _teamRepository;

        public ViewTeamsUseCase(ITeamRepository teamRepository) {
            _teamRepository = teamRepository;
        }
        public async Task<List<Team>> ExecuteAsync(string filterText) {
            return await _teamRepository.GetTeamsAsync(filterText);
        }
    }
}
