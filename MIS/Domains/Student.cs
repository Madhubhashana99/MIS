using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS.Domains
{
    [Table("student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]
        public required int Id { get; set; }
        
        [Column("firstname")]
        public required string FirstName { get; set; }

        [Column("lastname")]
        public required string LastName { get; set; }

        [Column("dateofbirth")]
        public required DateTime DateOfBirth { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("address")]
        public required string Address { get; set; }

        [Column("phone_no")]
        public required int Phone_no { get; set; }
    }
}
