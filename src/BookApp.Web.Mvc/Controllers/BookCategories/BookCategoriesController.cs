using Abp.Application.Services.Dto;
using BookApp.BookCategories;
using BookApp.BookCategories.Dto;
using BookApp.Controllers;
using BookApp.Departments;
using BookApp.Web.Models.BookCategories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Web.Controllers.BookCategories
{
    public class BookCategoriesController : BookAppControllerBase
    {
        private readonly IBookCategoriesAppService _bookCategoriesAppService;
        private readonly IDepartmentAppService _departmentAppSerivce;

        public BookCategoriesController (IBookCategoriesAppService bookCategoriesAppService, IDepartmentAppService departmentAppService)
        {
            _bookCategoriesAppService = bookCategoriesAppService;
            _departmentAppSerivce = departmentAppService;
        }

        public async Task<IActionResult> Index()
        {
            var bookcategories = await _bookCategoriesAppService.GetAllAsync(new PagedBookCategoriesResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new BookCategoriesListViewModel()
            {
                BookCategories = bookcategories.Items.ToList()
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var model = new CreateBookCategoriesViewModel();
            var departments = await _departmentAppSerivce.GetAllDepartments();

            if (id != 0)
            {
                var bookcategory = await _bookCategoriesAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateBookCategoriesViewModel()
                {
                    Name = bookcategory.Name,
                    DepartmentId = bookcategory.DepartmentId,
                    Id = id
                };
            }
            model.ListDepartments = departments;

            return View(model);
        }
    }
}
