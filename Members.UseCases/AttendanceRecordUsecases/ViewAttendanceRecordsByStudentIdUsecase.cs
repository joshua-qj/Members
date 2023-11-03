using Members.CoreBusiness;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.AttendanceRecordUseCases {
    public class ViewAttendanceRecordsByStudentIdUseCase {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public ViewAttendanceRecordsByStudentIdUseCase(IAttendanceRecordRepository attendanceRecordRepository) {
            _attendanceRecordRepository = attendanceRecordRepository;
        }

        public async Task<List<AttendanceRecord>> ExecuteAsync(int studentId) {
            return await _attendanceRecordRepository.GetAttendanceRecordsByStudentIdAsync(studentId);
        }
    }
}
