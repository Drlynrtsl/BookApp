using Abp.Application.Services;
using Abp.Domain.Repositories;
using BookApp.Entities;
using BookApp.Students.Dto;
using BookApp.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Departments.Dto;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Departments
{
    public class DepartmentAppService : AsyncCrudAppService<Department, DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, DepartmentDto>, IDepartmentAppService
    {
        private readonly IRepository<Department, int> _repository;
        public DepartmentAppService(IRepository<Department, int> repository) : base(repository)
        {
            _repository = repository;
        }

        public override Task<PagedResultDto<DepartmentDto>> GetAllAsync(PagedDepartmentResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
            var query = await _repository.GetAll().Select(x => ObjectMapper.Map<DepartmentDto>(x)).ToListAsync();
            return query;
        }

        public override Task<DepartmentDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<DepartmentDto> UpdateAsync(DepartmentDto input)
        {
            return base.UpdateAsync(input);
        }
    }
    
}
