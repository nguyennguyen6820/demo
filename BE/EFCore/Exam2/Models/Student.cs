namespace Exam2.Models
{
    public class Student
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public bool Status { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
