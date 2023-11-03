using Members.CoreBusiness;
using Members.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Members.Plugin.DataStore.SQLiteWithEFCore {
    public class AttendanceRecordSQLiteEFCoreRepository : IAttendanceRecordRepository {
        private readonly ApplicationDbContext _context;

        public AttendanceRecordSQLiteEFCoreRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task AddAttendanceRecordAsync(int studentId, AttendanceRecord attendanceRecord) { 
            attendanceRecord.StudentId = studentId;
                await _context.AttendanceRecords.AddAsync(attendanceRecord);
                await _context.SaveChangesAsync();            
            return;
        }

        public async Task<List<AttendanceRecord>> GetAttendanceRecordsAsync() {
            var attendanceRecords = await _context.AttendanceRecords.ToListAsync();
            if (attendanceRecords is not null) {
                return attendanceRecords;
            }
            return new List<AttendanceRecord>();
        }

        public async Task<AttendanceRecord> GetAttendanceRecordsByAttendanceRecordId(int attendanceRecordId) {
            if (attendanceRecordId > 0) {
                var attendanceRecord = await _context.AttendanceRecords.Where(a => a.AttendanceRecordId == attendanceRecordId).FirstOrDefaultAsync();
                if (attendanceRecord != null) {
                    return attendanceRecord;
            }
            }
            return new AttendanceRecord();
        }


        public async Task<List<AttendanceRecord>> GetAttendanceRecordsByStudentIdAsync(int studentId) {
            if (studentId > 0) {
                var attendanceRecords = await _context.AttendanceRecords.Where(a => a.StudentId == studentId).ToListAsync();
                if (attendanceRecords != null) {
                    return attendanceRecords;
                }
            }
            return new List<AttendanceRecord>();
        }

    }
    
}
