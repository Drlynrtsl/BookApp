using Abp.Application.Services;
using BookApp.Departments.Dto;
using BookApp.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Departments
{
    public interface IDepartmentAppService : IAsyncCrudAppService<DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, DepartmentDto>
    {
        Task<List<DepartmentDto>> GetAllDepartments();
    }
}
