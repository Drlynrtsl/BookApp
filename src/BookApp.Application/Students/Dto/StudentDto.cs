using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookApp.Entities;
using BookApp.Departments.Dto;

namespace BookApp.Students.Dto
{
    [AutoMapTo(typeof(Student))]
    [AutoMapFrom(typeof(Student))]
    public class StudentDto : EntityDto<int>
    {
        public string StudentName { get; set; }
        public string StudentContactNumber { get; set; }
        public string StudentEmail { get; set; }
        public int StudentDepartmentId { get; set; }
        public DepartmentDto StudentDepartment { get; set; }
    }
}
