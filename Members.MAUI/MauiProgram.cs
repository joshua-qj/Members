using Microsoft.Extensions.Logging;
using Members.UseCases.PluginInterfaces;
using CommunityToolkit.Maui;
using Members.MAUI.ViewModels;
using Members.MAUI.Views;
using Members.UseCases.Interfaces;
using Members.UseCases.TeamUsecases;
using Members.UseCases.StudentUsecases;
using Members.Plugin.DataStore.SQLite;

namespace Members.MAUI {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()       
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            .UseMauiCommunityToolkit()
                // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ITeamRepository, TeamSQLiteRepository>();
            builder.Services.AddSingleton<IStudentRepository, StudentSQLiteRepository>();


            builder.Services.AddSingleton<IViewTeamsUseCase, ViewTeamsUseCase>();
            builder.Services.AddSingleton<IViewTeamUseCase, ViewTeamUseCase>();
            builder.Services.AddSingleton<IAddTeamUseCase, AddTeamUseCase>();
            builder.Services.AddSingleton<IViewStudentsUseCase, ViewStudentsUseCase>();
            builder.Services.AddSingleton<IViewStudentUseCase, ViewStudentUseCase>();
            builder.Services.AddSingleton<IAddStudentUseCase, AddStudentUseCase>();

            builder.Services.AddTransient<TeamsViewModel>();
            builder.Services.AddTransient<TeamViewModel>();
            builder.Services.AddTransient<StudentsViewModel>();
            builder.Services.AddTransient<StudentViewModel>();



            builder.Services.AddSingleton<TeamsPage>();
            builder.Services.AddSingleton<EditTeamPage>();
            builder.Services.AddSingleton<AddTeamPage>();
            builder.Services.AddSingleton<StudentsPage>();
            builder.Services.AddSingleton<EditStudentPage>();
            builder.Services.AddSingleton<AddStudentPage>();
            return builder.Build();
        }
    }
}