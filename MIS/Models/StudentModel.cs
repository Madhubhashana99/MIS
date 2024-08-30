namespace MIS.Models
{
    public class StudentModel
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required int Phone_no { get; set; }
    }
}
