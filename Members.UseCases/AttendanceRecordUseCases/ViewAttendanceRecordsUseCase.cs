using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.AttendanceRecordUseCases
{
    public class ViewAttendanceRecordsUseCase : IViewAttendanceRecordsUseCase {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public ViewAttendanceRecordsUseCase(IAttendanceRecordRepository attendanceRecordRepository) {
            _attendanceRecordRepository = attendanceRecordRepository;
        }
        public async Task<List<AttendanceRecord>> ExecuteAsync() {
            return await _attendanceRecordRepository.GetAttendanceRecordsAsync();
        }
    }
}

