using System.ComponentModel.DataAnnotations;

namespace Bai2.Dto
{
    public class Markdto
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public int Scores { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
