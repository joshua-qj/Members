using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Members.CoreBusiness;
using Members.MAUI.Views;
using Members.UseCases.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.MAUI.ViewModels
{
    public partial class TeamViewModel : ObservableObject {
        private readonly IAddTeamUseCase _addTeamUseCase;
        private readonly IViewTeamUseCase _viewTeamUseCase;

        public TeamViewModel(IAddTeamUseCase addTeamUseCase,
                             //IEditTeamUseCase editTeamUseCase,
                             IViewTeamUseCase viewTeamUseCase) {
            Team = new Team();
            _addTeamUseCase = addTeamUseCase;
            _viewTeamUseCase = viewTeamUseCase;
        }
        private Team _team;

        public Team Team {
            get { return _team; }
            set { SetProperty(ref _team, value); }
        }

        public bool IsNameProvided { get; set; }

    
    public async Task LoadTeam(int TeamId) {
        Team = await _viewTeamUseCase.ExecuteAsync(TeamId);
    }

    [RelayCommand]
    private async Task EditTeam() {
        if (await ValidateTeam()) {
            //await _editTeamUseCase.ExecuteAsync(_Team.TeamId, _Team);
      
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
