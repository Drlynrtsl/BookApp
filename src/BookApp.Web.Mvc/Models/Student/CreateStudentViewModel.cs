using System.ComponentModel.DataAnnotations;

namespace BookApp.Web.Models.Student
{
    public class CreateStudentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentContactNumber { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        [Required]
        public string StudentDepartment { get; set; }
    }
}
