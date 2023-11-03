using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.TeamUseCases {
    public class DeleteTeamUseCase : IDeleteTeamUseCase {
        private readonly ITeamRepository _teamRepository;

        public DeleteTeamUseCase(ITeamRepository teamRepository) {
            _teamRepository = teamRepository;
        }

        public async Task ExecuteAsync(int teamId) {
            await _teamRepository.DeleteTeamAsync(teamId);
        }
    }
}
