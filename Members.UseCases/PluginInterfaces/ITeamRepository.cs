using Members.CoreBusiness;

namespace Members.UseCases.PluginInterfaces
{
    public interface ITeamRepository {
        Task AddTeamAsync(Team team);

        Task<List<Team>> GetTeamsAsync(string filterText);
        Task<Team> ViewTeamAsync(int teamId);
    }
}