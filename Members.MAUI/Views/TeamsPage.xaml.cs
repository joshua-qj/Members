using Members.MAUI.ViewModels;
using System.Collections.ObjectModel;
using Members.CoreBusiness;

namespace Members.MAUI.Views;

public partial class TeamsPage : ContentPage
{
    private readonly TeamsViewModel _teamsViewModel;

    public TeamsPage(TeamsViewModel teamsViewModel)
	{
		InitializeComponent();
        _teamsViewModel = teamsViewModel;
        this.BindingContext = _teamsViewModel;
    }




    protected override async void OnAppearing() {
        base.OnAppearing();
        SearchBar.Text = string.Empty;
        await _teamsViewModel.LoadTeamsAsync();
    }









}