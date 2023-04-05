using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Entities
{
    public class Student : FullAuditedEntity<int>
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentContactNumber { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        
        public int? StudentDepartmentId { get; set; }
        public Department StudentDepartment { get; set; }

    }
}
