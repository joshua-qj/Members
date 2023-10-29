using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Members.CoreBusiness {
    public class Team {
        [PrimaryKey, AutoIncrement]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        // If you want to set up a one-to-many relationship with ShoppingItem
        [Ignore]
        public List<Student> Students { get; set; }
    }
}
