using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;


namespace Members.UseCases.TeamUsecases {
    public class EditTeamUseCase : IEditTeamUseCase {
        private readonly ITeamRepository _teamRepository;

        public EditTeamUseCase(ITeamRepository teamRepository) {
            _teamRepository = teamRepository;
        }
        public async Task ExecuteAsync(int teamId, Team team) {
            await _teamRepository.UpdateTeam(teamId, team);
        }
    }
}
