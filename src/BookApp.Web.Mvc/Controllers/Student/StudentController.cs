using BookApp.Controllers;
using Abp.Application.Services.Dto;
using BookApp.Students;
using BookApp.Students.Dto;
using BookApp.Web.Models.Student;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BookApp.Web.Controllers.Student
{
    public class StudentController : BookAppControllerBase
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }


        public async Task<IActionResult> Index()
        {
            var students = await _studentAppService.GetAllAsync(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new StudentListViewModel
            {
                Students = students.Items.ToList()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var model = new CreateStudentViewModel();

            if (id != 0)
            {
                var student = await _studentAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateStudentViewModel()
                {
                    StudentName = student.StudentName,
                    StudentContactNumber = student.StudentContactNumber,
                    StudentEmail = student.StudentEmail,
                    StudentDepartment = student.StudentDepartment,
                    Id = id
                };                


            }
            return View(model);
        }
           
    }

}
