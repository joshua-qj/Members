using SQLite;

namespace Members.CoreBusiness {
    public class AttendanceRecord {
        [PrimaryKey, AutoIncrement]
        public int AttendanceRecordId { get; set; }

        // Foreign key for Student
        [Indexed]
        public int StudentId { get; set; }

        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public bool IsLeave { get; set; }

        // Navigation property
        [Ignore]
        public Student Student { get; set; }
    }
}
