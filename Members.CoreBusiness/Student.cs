using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Members.CoreBusiness {
    public class Student {
        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber{ get; set; }
        public string Email { get; set; }

        public bool IsBrought { get; set; }

        // Add Category properties
        public int? TeamId { get; set; }

        [Ignore]
        public Team Team { get; set; }
    }
}
