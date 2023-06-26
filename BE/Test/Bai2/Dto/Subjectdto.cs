using System.ComponentModel.DataAnnotations;

namespace Bai2.Dto
{
    public class Subjectdto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        
        public bool Status { get; set; }
    }
}
