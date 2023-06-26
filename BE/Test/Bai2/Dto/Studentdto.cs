using System.ComponentModel.DataAnnotations;

namespace Bai2.Dto
{
    public class Studentdto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public bool Status { get; set; }
    }
}
