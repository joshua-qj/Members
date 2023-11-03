using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using System.Collections.ObjectModel;

namespace Members.MAUI.ViewModels {
    public partial class AttendanceRecordsViewModel:ObservableObject {
        private string filterText;
        private readonly IViewAttendanceRecordsUseCase _viewAttendanceRecordsUseCase;
        public ObservableCollection<AttendanceRecord> AttendanceRecords { get; set; }
        public AttendanceRecordsViewModel(IViewAttendanceRecordsUseCase viewAttendanceRecordsUseCase) {
            _viewAttendanceRecordsUseCase = viewAttendanceRecordsUseCase;
            AttendanceRecords = new ObservableCollection<AttendanceRecord>();
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


        [RelayCommand]
    public async Task SearchBar_TextChangedAsync(string filter) {
        await LoadAttendanceRecordsAsync();
    }
}
}
