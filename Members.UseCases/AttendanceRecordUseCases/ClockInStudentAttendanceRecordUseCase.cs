using Members.CoreBusiness;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.AttendanceRecordUseCases {
    public class ClockInStudentAttendanceRecordUseCase : IClockInStudentAttendanceRecordUseCase {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public ClockInStudentAttendanceRecordUseCase(IAttendanceRecordRepository attendanceRecordRepository) {
            _attendanceRecordRepository = attendanceRecordRepository;
        }
        public async Task ExecuteAsync(int studentId, AttendanceRecord attendanceRecord) {
            await _attendanceRecordRepository.AddAttendanceRecordAsync(studentId, attendanceRecord);
        }
    }
}
