using Members.CoreBusiness;
using Members.Plugin.DataStore.SQLiteWithEFCore;
using Members.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using SQLite;
using System;

namespace Members.Plugin.DataStore.SQLite {
    public class TeamSQLiteEFCoreRepository : ITeamRepository {
        private readonly ApplicationDbContext _context;
        public TeamSQLiteEFCoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTeamAsync(Team team) {
            if (team != null) { 
                await _context.AddAsync(team);
                await _context.SaveChangesAsync(); }
            return;
        }

        public async Task DeleteTeamAsync(Team team) {
            if (team is not null) {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
            return;
        }

        public async Task<List<Team>> GetTeamsAsync(string filterText) {
            if (string.IsNullOrWhiteSpace(filterText)) {
                return await _context.Teams.ToListAsync();
            } else {
                return await _context.Teams.Where(t => t.Name.Contains(filterText)).ToListAsync();
            }
        }

        public async Task UpdateTeam(int teamId, Team team) {
            if (teamId != team.TeamId) { return; }
            var teamToUpdate = await _context.Teams.FindAsync(teamId);
            if (teamToUpdate is not null) {
                teamToUpdate.Name = team.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Team> ViewTeamAsync(int teamId) {
            if (teamId >0) {
                var team= await _context.Teams.Where(t => t.TeamId == teamId).FirstOrDefaultAsync();
               if (team != null) {
                    return team;
                }
            }
            return new Team();
        }
    }
}
