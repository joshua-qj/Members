using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Members.CoreBusiness;
using Members.MAUI.Views;
using Members.UseCases.Interfaces;

namespace Members.MAUI.ViewModels {
    public partial class TeamViewModel : ObservableObject {
        private Team _team;
        private readonly IAddTeamUseCase _addTeamUseCase;
        private readonly IEditTeamUseCase _editTeamUseCase;
        private readonly IViewTeamUseCase _viewTeamUseCase;

        public TeamViewModel(IAddTeamUseCase addTeamUseCase,
                             IEditTeamUseCase editTeamUseCase,
                             IViewTeamUseCase viewTeamUseCase) {
            Team = new Team();
            _addTeamUseCase = addTeamUseCase;
            _editTeamUseCase = editTeamUseCase;
            _viewTeamUseCase = viewTeamUseCase;
        }


        public Team Team {
            get => _team; 
            set { SetProperty(ref _team, value); }
        }

        public bool IsNameProvided { get; set; }

    
    public async Task LoadTeam(int TeamId) {
        Team = await _viewTeamUseCase.ExecuteAsync(TeamId);
    }

    [RelayCommand]
    private async Task EditTeam() {
        if (await ValidateTeam()) {
            await _editTeamUseCase.ExecuteAsync(_team.TeamId, _team);
               // await LoadTeam(_team.TeamId);
            await Shell.Current.GoToAsync($"//{nameof(TeamsPage)}");
        }
    }
    [RelayCommand]
    private async Task BackToTeams() {
        await Shell.Current.GoToAsync($"//{nameof(TeamsPage)}");
    }
    [RelayCommand]
    public async Task AddTeam() {
        if (await ValidateTeam()) {
            await _addTeamUseCase.ExecuteAsynce(_team);
            await Shell.Current.GoToAsync($"//{nameof(TeamsPage)}");
        }
    }

    private async Task<bool> ValidateTeam() {
        if (!IsNameProvided) {
            await Application.Current.MainPage.DisplayAlert("Error", "Name is required.", "OK");
            return false;
        }
        return true;
    }
}
}
