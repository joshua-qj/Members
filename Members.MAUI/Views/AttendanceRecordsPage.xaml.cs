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
   
        SearchBar.Text = string.Empty;
        await _attendanceRecordsViewModel.GetAuthenticatedStatusAsync();
        if (_attendanceRecordsViewModel.IsLogin) {
            await _attendanceRecordsViewModel.LoadAttendanceRecordsAsync();
            base.OnAppearing();
        } else {
            await Shell.Current.GoToAsync(nameof(LoginPage));
            base.OnAppearing();
        }
       
    }

}