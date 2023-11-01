using Members.CoreBusiness;
using Members.MAUI.ViewModels;

namespace Members.MAUI.Views;

public partial class AddStudentPage : ContentPage
{
    private readonly StudentViewModel _studentViewModel;

    public AddStudentPage(StudentViewModel studentViewModel)
	{
		InitializeComponent();
        _studentViewModel = studentViewModel;
        BindingContext = _studentViewModel;
    }
    protected override void OnAppearing() {
        base.OnAppearing();
        _studentViewModel.Student = new Student();
        _studentViewModel.SelectedTeam=new Team();
    }
}