using Members.CoreBusiness;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Members.MAUI.Views;
using Members.UseCases.Interfaces;
using Members.UseCases.TeamUsecases;

namespace Members.MAUI.ViewModels {
    public partial class TeamsViewModel : ObservableObject {

        public ObservableCollection<Team> Teams { get; set; }



        private string filterText;
        private readonly IViewTeamsUseCase _viewTeamsUseCase;
        private readonly IDeleteTeamUseCase _deleteTeamUseCase;

        public TeamsViewModel(IViewTeamsUseCase viewTeamsUseCase,IDeleteTeamUseCase deleteTeamUseCase)
        {
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
        public async Task LoadTeamsAsync(string filter = null) {
 
            Teams.Clear();
            var teams = await _viewTeamsUseCase.ExecuteAsync(filter);
            if (teams != null && teams.Count > 0) {
                foreach (var team in teams) {
                    Teams.Add(team);
                }
            }
        }
        [RelayCommand]
        public async Task DeleteTeam(Team team) {
            await _deleteTeamUseCase.ExecuteAsync(team);
            await LoadTeamsAsync();
        }

        [RelayCommand]
        public async Task GotoEditTeam(int id) {
            //await Shell.Current.GoToAsync($"{nameof(EditTeamPage)}?TeamId={id}");
        }
        [RelayCommand]
        private async Task GoToAddTeam() {
            await Shell.Current.GoToAsync($"{nameof(AddTeamPage)}");
        }
        [RelayCommand]
        public async Task SearchBar_TextChangedAsync(string filter) {
            await LoadTeamsAsync(filter);
        }
    }
}
