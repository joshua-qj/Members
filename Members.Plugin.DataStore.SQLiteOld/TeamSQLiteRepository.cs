using Members.CoreBusiness;
using Members.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.ApplicationModel.Communication;
using SQLite;

namespace Members.Plugin.DataStore.SQLite {
    public class TeamSQLiteRepository : ITeamRepository {
        private readonly AppDbContext _context;
        //private SQLiteAsyncConnection _database;
        public TeamSQLiteRepository(AppDbContext context)
        {
          //  _database = new SQLiteAsyncConnection(Constants.DatabasePath);
            //_database.CreateTableAsync<Team>();
            _context = context;
        }
        public async Task AddTeamAsync(Team team) {
             _context.Teams.Add(team);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Team>> GetTeamsAsync(string filterText) {
            if (string.IsNullOrWhiteSpace(filterText)) {
                return await _context.Teams.ToListAsync();
            }
            return null;
            //return await _database.QueryAsync<Team>(@"
            //                        SELECT * 
            //                        FROM Team 
            //                        WHERE
            //                            Name LIKE ? ",
            //                        $"%{filterText}%"
            //              );
        }

        public async Task<Team> ViewTeamAsync(int teamId) {
            return await _context.Teams.Where(t => t.TeamId == teamId).FirstOrDefaultAsync();
        }
    }
}
