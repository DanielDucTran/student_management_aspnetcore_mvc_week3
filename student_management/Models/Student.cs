using System.ComponentModel.DataAnnotations;

namespace student_management.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Mã Sinh Viên")]
        [Required(ErrorMessage ="Student Id is required")]
        public string Id { get; set; }
        [Display(Name ="Họ")]
        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }
        [Display(Name ="Tên")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Display(Name ="Ngày Sinh")]
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DataOfBirth { get; set; }
        [Display(Name ="Địa Chỉ")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set;}
        [Display(Name ="Giới Tính")]
        [Required(ErrorMessage ="Gender is required")]
        public string Gender { get; set;}
    }
}
