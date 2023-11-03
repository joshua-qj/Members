using Members.CoreBusiness;

namespace Members.UseCases.AttendanceRecordUseCases {
    public interface IClockOffStudentAttendanceRecordUseCase {
        Task ExecuteAsync(int studentId, AttendanceRecord attendanceRecord);
    }
}