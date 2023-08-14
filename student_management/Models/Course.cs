using System.ComponentModel.DataAnnotations;

namespace student_management.Models
{
    public class Course
    {
        [Key]
        [Display(Name = "Mã môn học")]
        [Required(ErrorMessage = "Course ID is required!")]
        public string CourseId { get; set; }
        [Required(ErrorMessage = "Course Name is required!")]
        [Display(Name = "Tên môn học")]
        public string CourseName { get; set; }
        [Display(Name = "Giáo Viên")]
        [Required(ErrorMessage = "Instructor is required!")]
        public string Instructor { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        [Required(ErrorMessage = "required!")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Ngày kết thúc")]
        [Required(ErrorMessage = "required!")]
        public DateTime EndDate { get; set; }
        public int MaxStudents { get; set; }

        //Relationships
        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
