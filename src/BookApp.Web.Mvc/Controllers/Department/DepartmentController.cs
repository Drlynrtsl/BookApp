using Abp.Application.Services.Dto;
using BookApp.Controllers;
using BookApp.Departments;
using BookApp.Departments.Dto;
using BookApp.Web.Models.Department;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Web.Controllers.Department
{
    public class DepartmentController : BookAppControllerBase
    {
        private readonly IDepartmentAppService _departmentAppService;

        public DepartmentController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentAppService.GetAllAsync(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new DepartmentListViewModel()
            {
                Department = departments.Items.ToList()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var model = new CreateDepartmentViewModel();
            //var departments = await _departmentAppService.GetAllDepartments();
            //ViewBag.Departments = departments;
            if (id != 0)
            {
                var department = await _departmentAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateDepartmentViewModel()
                {
                    Name = department.Name,
                    Id = id
                };
            }


            return View(model);
        }

        //[HttpPost]

        //public async Task <IActionResult> Update(int id)
        //{
        //    var model = new CreateDepartmentViewModel();

        //    if (id != 0)
        //    {
        //        var department = await _departmentAppService.GetAsync(new EntityDto<int>(id));
        //        model = new CreateDepartmentViewModel()
        //        {
        //            Name = department.Name,
        //            Id = id
        //        };
        //    }

        //    return View(model);
        //}
    }
}
