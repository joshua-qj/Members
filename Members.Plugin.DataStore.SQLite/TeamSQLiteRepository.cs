using Members.CoreBusiness;
using Members.UseCases.PluginInterfaces;
using Microsoft.Maui.ApplicationModel.Communication;
using SQLite;

namespace Members.Plugin.DataStore.SQLite {
    public class TeamSQLiteRepository : ITeamRepository {
        //private readonly AppDbContext _context;
        private SQLiteAsyncConnection _database;
        public TeamSQLiteRepository()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath);
            _database.CreateTableAsync<Team>();
            //_context = context;
        }
        public async Task AddTeamAsync(Team team) {
            await _database.InsertAsync(team);
            //await _context.SaveChangesAsync();
        }

        public Task DeleteTeamAsync(Team team) {
            throw new NotImplementedException();
        }

        public async Task<List<Team>> GetTeamsAsync(string filterText) {
            if (string.IsNullOrWhiteSpace(filterText)) {
                return await _database.Table<Team>().ToListAsync();
            }

            return await _database.QueryAsync<Team>(@"
                                    SELECT * 
                                    FROM Team 
                                    WHERE
                                        Name LIKE ? ",
                                    $"%{filterText}%"
                          );
        }

        public Task UpdateTeam(int teamId, Team team) {
            throw new NotImplementedException();
        }

        public async Task<Team> ViewTeamAsync(int teamId) {
            return await _database.Table<Team>().Where(t => t.TeamId == teamId).FirstOrDefaultAsync();
        }
    }
}
