using Members.CoreBusiness;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Members.MAUI.Views;
using Members.UseCases.Interfaces;

namespace Members.MAUI.ViewModels {
    public partial class StudentsViewModel : ObservableObject {
        public ObservableCollection<Student> Students { get; set; }

        private string filterText;
        private readonly IViewStudentsUseCase _viewStudentsUseCase;
        private readonly IDeleteStudentUseCase _deleteStudentUseCase;

        public StudentsViewModel(IViewStudentsUseCase viewStudentsUseCase, IDeleteStudentUseCase deleteStudentUseCase) {
            Students = new ObservableCollection<Student>();
            _viewStudentsUseCase = viewStudentsUseCase;
            _deleteStudentUseCase = deleteStudentUseCase;
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

            Students.Clear();
            var students = await _viewStudentsUseCase.ExecuteAsync(filter);
            if (students != null && students.Count > 0) {
                foreach (var team in students) {
                    Students.Add(team);
                }
            }
        }
        [RelayCommand]
        public async Task DeleteStudent(int studentId) {
            await _deleteStudentUseCase.ExecuteAsync(studentId);
            await LoadTeamsAsync();
        }

        [RelayCommand]
        public async Task GotoEditStudent(int id) {
            await Shell.Current.GoToAsync($"{nameof(EditStudentPage)}?StudentId={id}");
        }
        [RelayCommand]
        private async Task GoToAddStudent() {
            await Shell.Current.GoToAsync($"{nameof(AddStudentPage)}");
        }
        [RelayCommand]
        public async Task SearchBar_TextChangedAsync(string filter) {
            await LoadTeamsAsync(filter);
        }
    }
}

