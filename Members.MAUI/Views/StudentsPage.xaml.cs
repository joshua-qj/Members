using Members.MAUI.ViewModels;

namespace Members.MAUI.Views;

public partial class StudentsPage : ContentPage
{
    private readonly StudentsViewModel _studentsViewModelcs;

    public StudentsPage(StudentsViewModel studentsViewModelcs)
	{
		InitializeComponent();
        _studentsViewModelcs = studentsViewModelcs;
        BindingContext = _studentsViewModelcs;
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
       await _studentsViewModelcs.LoadStudentsAsync();
    }
}