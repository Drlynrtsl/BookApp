using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using BookApp.Students.Dto;
using BookApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Students
{
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>, IStudentAppService
    {
        private readonly IRepository<Student, int> _repository;
        public StudentAppService(IRepository<Student, int> repository) : base(repository)
        {
            _repository = repository;
        }

        public override Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            return base.CreateAsync(input);
        }
         
        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public async Task<List<StudentDto>> GetAllStudents()
        {
            var query = await _repository.GetAll()
                .Select(x => ObjectMapper.Map<StudentDto>(x))
                .ToListAsync();
            return query;
        }
        public override async Task<PagedResultDto<StudentDto>> GetAllAsync(PagedStudentResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.StudentDepartment)
                .Select(x => ObjectMapper.Map<StudentDto>(x))
                .ToListAsync();
            return new PagedResultDto<StudentDto>(query.Count(), query);
        }

        public override Task<StudentDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<StudentDto> UpdateAsync(StudentDto input)
        {
            return base.UpdateAsync(input);
        }
    }
}
