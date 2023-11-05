using SQLite;

namespace Members.CoreBusiness {
    public class AttendanceRecord {
        [PrimaryKey, AutoIncrement]
        public int AttendanceRecordId { get; set; }

        // Foreign key for Student

        public int StudentId { get; set; }
        public int? TeamId { get; set; }

        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public bool IsLeave { get; set; }

        public string ClockInOutStatus {
            get {
                return IsPresent && IsLeave
                    ? "Both clocked in and out"
                    : IsPresent ? "Present" :
                    IsLeave ? "Leave" : "Not clocked in or out";
            }
        }

        // Navigation property
        [Ignore]
        public Student Student { get; set; }
    }
}
