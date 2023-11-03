using Members.CoreBusiness;

namespace Members.UseCases.Interfaces
{
    public interface IViewAttendanceRecordsUseCase
    {
        Task<List<AttendanceRecord>> ExecuteAsync();
    }
}