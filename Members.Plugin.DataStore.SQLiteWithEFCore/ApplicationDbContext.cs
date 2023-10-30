using Members.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Members.Plugin.DataStore.SQLiteWithEFCore {
    public class ApplicationDbContext:DbContext {
        public ApplicationDbContext()
        {
                //Constructor with no argument is required and it is used when adding removing migrations from class library.
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) {
            Database.EnsureCreated();
            Database.Migrate();
        }
        //It is required to override this method when addingremoving migrations from class library from class library
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite();
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Student> Students  { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Team)
                .WithMany(t => t.Students)
                .HasForeignKey(s => s.TeamId);
        }
        /*dotnet ef migrations add Initial --startup-project .\Members.Plugin.DataStore.SQLiteWithEFCore --project .\Members.Plugin.DataStore.SQLiteWithEFCore*/
    }
}
