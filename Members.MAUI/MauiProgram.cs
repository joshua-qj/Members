using Microsoft.Extensions.Logging;
using Members.UseCases.PluginInterfaces;
using CommunityToolkit.Maui;
using Members.MAUI.ViewModels;
using Members.MAUI.Views;
using Members.UseCases.Interfaces;
using Members.Plugin.DataStore.SQLite;
using Members.Plugin.DataStore.SQLiteWithEFCore;
using Microsoft.EntityFrameworkCore;
using Members.MAUI.Helper;
using Members.UseCases.StudentUseCases;
using Members.UseCases.TeamUseCases;
using Members.UseCases.AttendanceRecordUseCases;

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
            //builder.Services.AddDbContext<ApplicationDbContext>(options => {
            //    options.UseSqlite($"Filename={DatabasePath.GetDatabasePath()}", x => x.MigrationsAssembly(nameof(MauiClassLibrary)));
            //});

            builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlite($"Filename={DatabasePath.GetDatabasePath()}",
    x => x.MigrationsAssembly("Members.Plugin.DataStore.SQLiteWithEFCore")));
            builder.Services.AddSingleton<ITeamRepository, TeamSQLiteEFCoreRepository>();
            builder.Services.AddSingleton<IStudentRepository, StudentSQLiteEFCoreRepository>();
            builder.Services.AddSingleton<IAttendanceRecordRepository, AttendanceRecordSQLiteEFCoreRepository>();


            builder.Services.AddTransient<IViewTeamsUseCase, ViewTeamsUseCase>();
            builder.Services.AddTransient<IViewTeamUseCase, ViewTeamUseCase>();
            builder.Services.AddTransient<IDeleteTeamUseCase, DeleteTeamUseCase>();
            builder.Services.AddTransient<IEditTeamUseCase, EditTeamUseCase>();
            builder.Services.AddTransient<IAddTeamUseCase, AddTeamUseCase>();

            builder.Services.AddTransient<IViewStudentsUseCase, ViewStudentsUseCase>();
            builder.Services.AddTransient<IViewStudentUseCase, ViewStudentUseCase>();
            builder.Services.AddTransient<IAddStudentUseCase, AddStudentUseCase>();
            builder.Services.AddTransient<IDeleteStudentUseCase, DeleteStudentUseCase>();
            builder.Services.AddTransient<IEditStudentUseCase, EditStudentUseCase>();

            builder.Services.AddSingleton<IClockInStudentAttendanceRecordUseCase,ClockInStudentAttendanceRecordUseCase>();
            builder.Services.AddSingleton<IClockOffStudentAttendanceRecordUseCase, ClockOffStudentAttendanceRecordUseCase>();
            builder.Services.AddSingleton<IViewAttendanceRecordsUseCase, ViewAttendanceRecordsUseCase>();

            builder.Services.AddSingleton<TeamsViewModel>();
            builder.Services.AddSingleton<TeamViewModel>();
            builder.Services.AddSingleton<StudentsViewModel>();
            builder.Services.AddSingleton<StudentViewModel>();
            builder.Services.AddSingleton<AttendanceRecordsViewModel>();



            builder.Services.AddSingleton<TeamsPage>();
            builder.Services.AddSingleton<EditTeamPage>();
            builder.Services.AddSingleton<AddTeamPage>();
            builder.Services.AddSingleton<StudentsPage>();
            builder.Services.AddSingleton<EditStudentPage>();
            builder.Services.AddSingleton<AddStudentPage>();
            builder.Services.AddSingleton<AttendanceRecordsPage>();
            return builder.Build();
        }
    }
}