namespace Exam2.Models
{
    public class Mark
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Scores { get; set; }
        public DateTime CreateDate { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
