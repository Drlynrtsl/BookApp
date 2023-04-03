using BookApp.Departments.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookApp.Web.Models.Department
{
    public class DepartmentListViewModel
    {
        public List <DepartmentDto> Department { get; set; } 
    }
}
