using Members.CoreBusiness;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.AttendanceRecordUseCases {
    public class ClockOffStudentAttendanceRecordUseCase : IClockOffStudentAttendanceRecordUseCase {
        public readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public ClockOffStudentAttendanceRecordUseCase(IAttendanceRecordRepository attendanceRecordRepository) {
            _attendanceRecordRepository = attendanceRecordRepository;
        }
        public async Task ExecuteAsync(int studentId,AttendanceRecord attendanceRecord) {
            await _attendanceRecordRepository.AddAttendanceRecordAsync(studentId,attendanceRecord);
        }
    }
}
