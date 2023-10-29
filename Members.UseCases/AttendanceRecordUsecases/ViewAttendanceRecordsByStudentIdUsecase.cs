using Members.CoreBusiness;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.AttendanceRecordUsecases
{
    public class ViewAttendanceRecordsByStudentIdUsecase
    {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public ViewAttendanceRecordsByStudentIdUsecase(IAttendanceRecordRepository attendanceRecordRepository)
        {
            _attendanceRecordRepository = attendanceRecordRepository;
        }

        public async Task<List<AttendanceRecord>> ExecuteAsync(int studentId)
        {
            return await _attendanceRecordRepository.GetAttendanceRecordsByStudentId(studentId);
        }
    }
}
