using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
