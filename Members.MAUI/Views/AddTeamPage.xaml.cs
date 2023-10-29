using Members.MAUI.ViewModels;

namespace Members.MAUI.Views;

public partial class AddTeamPage : ContentPage
{
    private readonly TeamViewModel _teamViewModel;

    public AddTeamPage(TeamViewModel teamViewModel)
	{
		InitializeComponent();
        _teamViewModel = teamViewModel;
        BindingContext= _teamViewModel; 
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        _teamViewModel.Team=new CoreBusiness.Team();
    }
}