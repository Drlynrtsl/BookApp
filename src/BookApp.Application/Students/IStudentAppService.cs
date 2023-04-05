using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookApp.Books.Dto;
using BookApp.Borrows.Dto;
using BookApp.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Students
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>
    {
        Task<List<StudentDto>> GetAllStudents();
    }
}
