using Members.CoreBusiness;

namespace Members.UseCases.PluginInterfaces {
    public interface IAttendanceRecordRepository {
        // AttendanceRecord GetAttendanceRecordsByStudentId(int studentId);
       Task <List<AttendanceRecord>> GetAttendanceRecordsByStudentId(int studentId);
    }
}
