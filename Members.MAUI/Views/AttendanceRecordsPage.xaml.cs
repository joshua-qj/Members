using Members.MAUI.ViewModels;

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
        await _attendanceRecordsViewModel.LoadAttendanceRecordsAsync();
    }
}