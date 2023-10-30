using Members.MAUI.Views;
namespace Members.MAUI {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddTeamPage), typeof(AddTeamPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(AddStudentPage), typeof(AddStudentPage));
            Routing.RegisterRoute(nameof(EditStudentPage), typeof(EditStudentPage));
            Routing.RegisterRoute(nameof(EditTeamPage), typeof(EditTeamPage));
            Routing.RegisterRoute(nameof(StudentsPage), typeof(StudentsPage));
            Routing.RegisterRoute(nameof(TeamsPage), typeof(TeamsPage));
            // Routing.RegisterRoute(nameof(EditTeamPage),typeof(AddTeamPage));
        }
    }
}