using Microsoft.EntityFrameworkCore;
using Members.CoreBusiness;
using Microsoft.EntityFrameworkCore.Sqlite;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Plugin.DataStore.SQLite {
    public class AppDbContext : DbContext {

        public DbSet<Student> Students { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=MembersSQLite.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Team)
                .WithMany(t => t.Students)
                .HasForeignKey(s => s.TeamId);
        }
    }
}
