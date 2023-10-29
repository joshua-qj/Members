using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.UseCases.TeamUsecases
{
    public class AddTeamUseCase : IAddTeamUseCase {
        private readonly ITeamRepository _teamRepository;

        public AddTeamUseCase(ITeamRepository teamRepository) {
            _teamRepository = teamRepository;
        }
        public async Task ExecuteAsynce(Team team) {
            await _teamRepository.AddTeamAsync(team);
        }
    }
}
