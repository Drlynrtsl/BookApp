using Abp.Application.Services.Dto;
using BookApp.BookCategories;
using BookApp.BookCategories.Dto;
using BookApp.Books;
using BookApp.Books.Dto;
using BookApp.Borrows;
using BookApp.Borrows.Dto;
using BookApp.Controllers;
using BookApp.Departments;
using BookApp.Departments.Dto;
using BookApp.Students;
using BookApp.Students.Dto;
using BookApp.Web.Models.Borrow;
using BookApp.Web.Models.Department;
using BookApp.Web.Models.Student;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Web.Controllers.Borrow
{
    public class BorrowController : BookAppControllerBase
    {
        private readonly IBorrowAppService _borrowAppService;
        private readonly IBookAppService _bookAppService;
        private readonly IStudentAppService _studentAppService;
        private readonly IDepartmentAppService _departmentAppService;
        private readonly IBookCategoriesAppService _bookCategoriesAppService;

        public BorrowController(IBorrowAppService borrowAppService, IBookAppService bookAppService, IStudentAppService studentAppService, IDepartmentAppService departmentAppService, IBookCategoriesAppService bookCategoriesAppService)
        {
            _borrowAppService = borrowAppService;
            _bookAppService = bookAppService;
            _studentAppService = studentAppService;
            _departmentAppService = departmentAppService;
            _bookCategoriesAppService = bookCategoriesAppService;
        }
       
        public async Task<IActionResult> Index()
        {
            var borrows = await _borrowAppService.GetAllAsync(new PagedBorrowResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new BorrowListViewModel()
            {
                Borrows = borrows.Items.ToList()
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var model = new CreateBorrowViewModel();
            var books = new List<BookDto>();
            var students = new List <StudentDto>();
            var departments = new List<DepartmentDto>();
            var bookcategories = new List<BookCategoriesDto>();

            if (id != 0) //Update
            {
                var borrow = await _borrowAppService.GetBorrowWithBookAndStudentUnderBookCategory(new EntityDto<int>(id));
                model = new CreateBorrowViewModel()
                {
                    BorrowDate = borrow.BorrowDate,
                    ExpectedReturnDate = borrow.ExpectedReturnDate,
                    ReturnDate = borrow.ReturnDate,
                    BookId = borrow.BookId,
                    BookTitle = borrow.BookTitle,
                    StudentId = borrow.StudentId,
                    StudentName = borrow.StudentName,
                    StudentDepartmentId = borrow.StudentDepartmentId,
                    Id = id,
                    IsBorrowed = borrow.Book.IsBorrowed,
                    DepartmentId = borrow.DepartmentId,
                    DepartmentName = borrow.DepartmentName,
                    BookCategoriesId = borrow.BookCategoriesId,
                    BookCategoriesName = borrow.BookCategoriesName
                };               

                books.Add(ObjectMapper.Map<BookDto>(borrow.Book));
                students.Add(ObjectMapper.Map<StudentDto>(borrow.Student));
                departments.Add(ObjectMapper.Map<DepartmentDto>(borrow.Department));
                bookcategories.Add(ObjectMapper.Map<BookCategoriesDto>(borrow.BookCategories));
            }
             else //Create
            {
                books = await _bookAppService.GetAvailableBooks();
                students = await _studentAppService.GetAllStudents();
                departments = await _departmentAppService.GetAllDepartments();
                bookcategories = await _bookCategoriesAppService.GetAllBookCategories();
            }
            
            model.ListBooks = books;
            model.ListStudents = students;
            model.ListDepartments = departments;
            model.ListBookCategories = bookcategories;
            //ViewBag.model = departments;

            return View(model);
        }      
    }
}
