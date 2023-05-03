using Abp.AutoMapper;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Departments.Dto
{
    [AutoMapTo(typeof(Department))]
    public class CreateDepartmentDto
    {        
        [Required]
        public string Name { get; set; }
    }
}
