using Members.CoreBusiness;

namespace Members.UseCases.PluginInterfaces {
    public interface IAttendanceRecordRepository {
       Task <AttendanceRecord> GetAttendanceRecordsByAttendanceRecordId(int attendanceRecordId);
        Task AddAttendanceRecordAsync(int studentId, AttendanceRecord attendanceRecord);
        Task<List<AttendanceRecord>> GetAttendanceRecordsByStudentIdAsync(int studentId);
        Task<List<AttendanceRecord>> GetAttendanceRecordsAsync();
   
    }
}
