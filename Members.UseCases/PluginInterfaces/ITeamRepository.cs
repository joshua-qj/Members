using Members.CoreBusiness;

namespace Members.UseCases.PluginInterfaces
{
    public interface ITeamRepository {
        Task AddTeamAsync(Team team);
        Task DeleteTeamAsync(int teamId);
        Task<List<Team>> GetTeamsAsync(string filterText);
        Task UpdateTeam(int teamId, Team team);
        Task<Team> GetTeamByIdAsync(int teamId);
    }
}