using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Departments.Dto
{
    [AutoMapTo(typeof(Department))]
    [AutoMapFrom(typeof(Department))]
    public class DepartmentDto : EntityDto<int>
    {        
        public string Name { get; set; }
    }
}
