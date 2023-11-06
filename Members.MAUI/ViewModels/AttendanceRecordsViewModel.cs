using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using System.Collections.ObjectModel;

namespace Members.MAUI.ViewModels {
    public partial class AttendanceRecordsViewModel : ObservableObject {
        private string filterText;
        private readonly IViewAttendanceRecordsUseCase _viewAttendanceRecordsUseCase;
        public ObservableCollection<AttendanceRecord> AttendanceRecords { get; set; }
        DateTime _time1;

        public DateTime Time1 {
            get => _time1;
            set => SetProperty(ref _time1, value);
        }
        public AttendanceRecordsViewModel(IViewAttendanceRecordsUseCase viewAttendanceRecordsUseCase) {
            _viewAttendanceRecordsUseCase = viewAttendanceRecordsUseCase;
            AttendanceRecords = new ObservableCollection<AttendanceRecord>();
            Time1 = DateTime.Now;
        }



        public string FilterText {
            get { return filterText; }
            set {
                filterText = value;
                LoadAttendanceRecordsMethod(filterText); //remove squiggy line, use     private async void  to wrap async method.
            }
        }

        private async void LoadAttendanceRecordsMethod(string filterText) {
            await LoadAttendanceRecordsAsync(filterText);
        }
        public async Task LoadAttendanceRecordsAsync(string filterText = null) {
            AttendanceRecords.Clear();
            var attendanceRecords = await _viewAttendanceRecordsUseCase.ExecuteAsync();
            attendanceRecords = attendanceRecords.OrderBy(a => a.Student.FirstName).ToList();
            if (attendanceRecords != null && attendanceRecords.Count > 0) {
                foreach (var attendance in attendanceRecords) {
                    this.AttendanceRecords.Add(attendance);
                }
            }
        }
        private async Task LoadAttendanceRecordsAsyncByDate(DateTime dateTime) {
            AttendanceRecords.Clear();
            var attendanceRecords = await _viewAttendanceRecordsUseCase.ExecuteAsync();
            attendanceRecords = attendanceRecords.Where(a=>a.Date.Day==dateTime.Date.Day).OrderBy(a => a.Student.FirstName).ToList();
            if (attendanceRecords != null && attendanceRecords.Count > 0) {
                foreach (var attendance in attendanceRecords) {
                    this.AttendanceRecords.Add(attendance);
                }
            }
        }

        [RelayCommand]
        public async Task SearchBar_TextChangedAsync(string filter) {
            await LoadAttendanceRecordsAsync();
        }
        [RelayCommand]
        public async Task LoadAttendanceRecordsByDate() {
            await LoadAttendanceRecordsAsyncByDate(_time1);
        }


    }
}
