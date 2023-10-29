using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Members.CoreBusiness;
using Members.MAUI.Views;
using Members.UseCases.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Members.MAUI.ViewModels {
    public partial class StudentViewModel : ObservableObject {
        private ObservableCollection<Team> _teams;
        private Student _student;
        private readonly IViewStudentUseCase _viewStudentUseCase;
        private readonly IViewTeamsUseCase _viewTeamsUseCase;
        private readonly IAddStudentUseCase _addStudentUseCase;
        private Team _selectedTeam;

        public ObservableCollection<Team> Teams {
            get => _teams;
            set => SetProperty(ref _teams, value);
        }
        public Team SelectedTeam {
            get => _selectedTeam;
            set {
                SetProperty(ref _selectedTeam, value);
                Student.TeamId = value?.TeamId;
            }
        }

        private List<string> _teamName;

        public List<string> TeamName {
            get { return _teamName; }
            set { _teamName = value; }
        }

        public Student Student {
            get { return _student; }
            set { SetProperty(ref _student, value); }
        }

        public bool IsNameProvided { get; set; }
        public bool IsEmailProvided { get; set; }
        public bool IsEmailFormatValid { get; set; }

        public StudentViewModel(IViewStudentUseCase viewStudentUseCase,
                                IViewTeamsUseCase viewTeamsUseCase,
                                IAddStudentUseCase addStudentUseCase) {
            Student = new Student();
            _teamName=new List<string>();
            _viewStudentUseCase = viewStudentUseCase;
            _viewTeamsUseCase = viewTeamsUseCase;
            LoadTeams();
            _addStudentUseCase = addStudentUseCase;

        }
        public async Task LoadStudent(int studentId) {
            Student = await _viewStudentUseCase.ExecuteAsync(studentId);
        }

        public async void LoadTeams() {
            var teams = await _viewTeamsUseCase.ExecuteAsync(string.Empty);
            Teams = new ObservableCollection<Team>(teams);
                if (Teams is not null && Teams.Count > 0) {
                    foreach (var team in Teams) {
                        _teamName.Add(team.Name);
                    }
                }
            
        }

        [RelayCommand]
        private async Task EditStudent() {
            if (await ValidateStudent()) {
                //await _editStudentUseCase.ExecuteAsync(_Student.StudentId, _Student);
                ////       await LoadStudent(Student.StudentId);
                //await Shell.Current.GoToAsync($"{nameof(Students_MVVM_Page)}");
            }
        }
        [RelayCommand]
        private async Task BackToStudents() {
            await Shell.Current.GoToAsync($"//{nameof(StudentsPage)}");
        }
        [RelayCommand]
        public async Task AddStudent() {
            if (await ValidateStudent()) {
                await _addStudentUseCase.ExecuteAsync(Student);
                await Shell.Current.GoToAsync($"//{nameof(StudentsPage)}");
            }
        }

        private async Task<bool> ValidateStudent() {
            if (!IsNameProvided) {
                await Application.Current.MainPage.DisplayAlert("Error", "Name is required.", "OK");
                return false;
            }
            if (!IsEmailProvided) {
                await Application.Current.MainPage.DisplayAlert("Error", "Email is required.", "OK");
                return false;
            }
            if (!IsEmailFormatValid) {
                await Application.Current.MainPage.DisplayAlert("Error", "Email format is not correct.", "OK");
                return false;
            }
            return true;
        }
    }
}

