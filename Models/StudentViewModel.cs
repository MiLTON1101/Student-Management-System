using System.ComponentModel.DataAnnotations;

namespace StudentsDatabase.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [Required]
        public string? Address { get; set; }


    }
}
