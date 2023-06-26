using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Exam2.Dtos
{
    public class SubjectDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
