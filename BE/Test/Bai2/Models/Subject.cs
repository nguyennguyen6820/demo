using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai2.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Mark> Marks { get; set; }
      
        
    }
}
