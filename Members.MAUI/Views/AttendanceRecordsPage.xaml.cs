using Members.MAUI.ViewModels;
using System.Runtime.CompilerServices;

namespace Members.MAUI.Views;

public partial class AttendanceRecordsPage : ContentPage
{
    private readonly AttendanceRecordsViewModel _attendanceRecordsViewModel;

    public AttendanceRecordsPage(AttendanceRecordsViewModel attendanceRecordsViewModel)
	{
		InitializeComponent();
        _attendanceRecordsViewModel = attendanceRecordsViewModel;
        BindingContext = _attendanceRecordsViewModel;
    }
    protected override async void OnAppearing() {
        base.OnAppearing();
        SearchBar.Text = string.Empty;
        if (_attendanceRecordsViewModel.IsLogin) {
            await _attendanceRecordsViewModel.LoadAttendanceRecordsAsync();
        }
    }
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        base.OnPropertyChanged(propertyName);
       // btnSave.SetBinding(Button.CommandProperty, "EditStudentCommand");
       if (_attendanceRecordsViewModel.IsLogin== false) {
            btnLog.SetBinding(Button.CommandProperty, "LoginCommand");
            btnLog.SetBinding(Button.TextProperty, "Login");
        }
        if (_attendanceRecordsViewModel.IsLogin == true) {
            btnLog.SetBinding(Button.CommandProperty, "LogoffCommand");
            btnLog.SetBinding(Button.TextProperty, "Log off");
        }
    }
}