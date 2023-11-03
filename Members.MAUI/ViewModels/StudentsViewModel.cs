using Members.CoreBusiness;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Members.MAUI.Views;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;
using Members.UseCases.AttendanceRecordUseCases;

namespace Members.MAUI.ViewModels {
    public partial class StudentsViewModel : ObservableObject {
        public ObservableCollection<Student> Students { get; set; }
        private AttendanceRecord _attendanceRecord;
        private string filterText;
        private readonly IViewStudentsUseCase _viewStudentsUseCase;
        private readonly IDeleteStudentUseCase _deleteStudentUseCase;
        private readonly IClockInStudentAttendanceRecordUseCase _clockInStudentAttendanceRecordUseCase;
        private readonly IClockOffStudentAttendanceRecordUseCase _clockOffStudentAttendanceRecordUseCase;
      

        public StudentsViewModel(IViewStudentsUseCase viewStudentsUseCase,
                                 IDeleteStudentUseCase deleteStudentUseCase,
                                 IClockInStudentAttendanceRecordUseCase clockInStudentAttendanceRecordUseCase,
                                 IClockOffStudentAttendanceRecordUseCase clockOffStudentAttendanceRecordUseCase) {
            Students = new ObservableCollection<Student>();
            _attendanceRecord=new AttendanceRecord();
            _viewStudentsUseCase = viewStudentsUseCase;
            _deleteStudentUseCase = deleteStudentUseCase;
            _clockInStudentAttendanceRecordUseCase = clockInStudentAttendanceRecordUseCase;
            _clockOffStudentAttendanceRecordUseCase = clockOffStudentAttendanceRecordUseCase;
        
        }
        public string FilterText {
            get { return filterText; }
            set {
                filterText = value;
                LoadStudentsMethod(filterText); //remove squiggy line, use     private async void  to wrap async method.
            }
        }

        private async void LoadStudentsMethod(string filterText) {
            await LoadStudentsAsync(filterText);
        }
        public async Task LoadStudentsAsync(string filter = null) {

            Students.Clear();
            var students = await _viewStudentsUseCase.ExecuteAsync(filter);
         students = students.OrderBy(s => s.Team?.Name).ThenBy(s => s.FirstName).ToList();
            if (students != null && students.Count > 0) {
                foreach (var team in students) {
                    Students.Add(team);
                }
            }
        }
        [RelayCommand]
        public async Task DeleteStudent(int studentId) {
            await _deleteStudentUseCase.ExecuteAsync(studentId);
            await LoadStudentsAsync();
        }

        [RelayCommand]
        public async Task GotoEditStudent(int studentId) {
            await Shell.Current.GoToAsync($"{nameof(EditStudentPage)}?Id={studentId}");
        }
        [RelayCommand]
        private async Task GoToAddStudent() {
            await Shell.Current.GoToAsync($"{nameof(AddStudentPage)}");
        }

        [RelayCommand]
        public async Task ClockInStudent(int studentId) {
            AttendanceRecord attendanceRecord = new AttendanceRecord();
            attendanceRecord.Date = DateTime.Now;
            attendanceRecord.IsPresent = true;
            await _clockInStudentAttendanceRecordUseCase.ExecuteAsync(studentId,attendanceRecord);
            await LoadStudentsAsync();
          //  attendanceRecord = new AttendanceRecord();
        }
        [RelayCommand]
        public async Task ClockOffStudent(int studentId) {
            AttendanceRecord attendanceRecord = new AttendanceRecord();
            attendanceRecord.Date = DateTime.Now;
            attendanceRecord.IsLeave = true;
            await _clockInStudentAttendanceRecordUseCase.ExecuteAsync(studentId, attendanceRecord);
            await LoadStudentsAsync();
          //  attendanceRecord=new AttendanceRecord();
        }
        [RelayCommand]
        public async Task SearchBar_TextChangedAsync(string filter) {
            await LoadStudentsAsync(filter);
        }
    }
}

