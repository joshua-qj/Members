using Members.CoreBusiness;

namespace Members.UseCases.AttendanceRecordUseCases {
    public interface IClockInStudentAttendanceRecordUseCase {
     
        Task ExecuteAsync(int studentId, AttendanceRecord attendanceRecord);
    }
}