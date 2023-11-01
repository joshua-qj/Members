using Members.MAUI.ViewModels;

namespace Members.MAUI.Views;
[QueryProperty(nameof(TeamId), "Id")]
public partial class EditTeamPage : ContentPage
{
    private readonly TeamViewModel _teamViewModel;
    public EditTeamPage(TeamViewModel teamViewModel)
	{
		InitializeComponent();
        _teamViewModel = teamViewModel;
        BindingContext = _teamViewModel;
    }

    public string TeamId { 
        set {
            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out int teamId)) {
                LoadContactAsync(teamId);
            } }
}

    private async void LoadContactAsync(int teamId) {
        await _teamViewModel.LoadTeam(teamId);
    }
}
