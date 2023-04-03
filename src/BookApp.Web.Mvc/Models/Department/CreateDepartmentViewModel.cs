using System.ComponentModel.DataAnnotations;

namespace BookApp.Web.Models.Department
{
    public class CreateDepartmentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
