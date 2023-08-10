using System.ComponentModel.DataAnnotations;

namespace student_management.Models
{
    public class Cource
    {
        [Key]
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
