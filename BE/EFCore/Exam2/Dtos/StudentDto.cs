using System.ComponentModel.DataAnnotations;

namespace Exam2.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
