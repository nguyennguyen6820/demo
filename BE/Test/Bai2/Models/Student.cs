using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public bool Status { get; set; }
        public List<Mark> Marks { get; set; } = new List<Mark>();
        
    }
}
