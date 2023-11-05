using Members.CoreBusiness;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Members.MAUI.Views;
using Members.UseCases.Interfaces;

namespace Members.MAUI.ViewModels {
    public partial class TeamsViewModel : ObservableObject {
        [ObservableProperty]
        private ObservableCollection<Team> _teams;
        //public ObservableCollection<Team> Teams {
        //    get => _teams;
        //    set { 
        //    SetProperty(ref _teams, value);
        //    }
        //}




        private string filterText;
        private readonly IViewTeamsUseCase _viewTeamsUseCase;
        private readonly IDeleteTeamUseCase _deleteTeamUseCase;

        public TeamsViewModel(IViewTeamsUseCase viewTeamsUseCase, IDeleteTeamUseCase deleteTeamUseCase) {
       
            Teams = new ObservableCollection<Team>();
            _viewTeamsUseCase = viewTeamsUseCase;
            _deleteTeamUseCase = deleteTeamUseCase;
        }
        public string FilterText {
            get { return filterText; }
            set {
                filterText = value;
                LoadTeamsMethod(filterText); //remove squiggy line, use     private async void  to wrap async method.
            }
        }

        private async void LoadTeamsMethod(string filterText) {
            await LoadTeamsAsync(filterText);
        }
        public async Task LoadTeamsAsync(string filterText = null) {
            
            Teams.Clear();
            var teams = await _viewTeamsUseCase.ExecuteAsync(filterText);
           teams = teams.OrderBy(team => team.Name).ToList();
            if (teams != null && teams.Count > 0) {
                foreach (var team in teams) {
                    this.Teams.Add(team);
                }
            }
        }
        [RelayCommand]
        public async Task DeleteTeam(int teamId) {
            await _deleteTeamUseCase.ExecuteAsync(teamId);
            await LoadTeamsAsync();
        }

        [RelayCommand]
        public async Task GotoEditTeam(int teamId) {
            await Shell.Current.GoToAsync($"{nameof(EditTeamPage)}?Id={teamId}");
        }
        [RelayCommand]
        private async Task GoToAddTeam() {
            await Shell.Current.GoToAsync($"{nameof(AddTeamPage)}");
        }
        [RelayCommand]
        public async Task SearchBar_TextChangedAsync(string filter) {
            await LoadTeamsAsync();
        }
    }
}
