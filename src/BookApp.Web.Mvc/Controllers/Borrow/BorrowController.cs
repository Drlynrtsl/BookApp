using Abp.Application.Services.Dto;
using BookApp.Books;
using BookApp.Borrows;
using BookApp.Borrows.Dto;
using BookApp.Controllers;
using BookApp.Students;
using BookApp.Web.Models.Borrow;
using BookApp.Web.Models.Department;
using BookApp.Web.Models.Student;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Web.Controllers.Borrow
{
    public class BorrowController : BookAppControllerBase
    {
        private readonly IBorrowAppService _borrowAppService;
        private readonly IBookAppService _bookAppService;
        private readonly IStudentAppService _studentAppService;

        public BorrowController(IBorrowAppService borrowAppService, IBookAppService bookAppService, IStudentAppService studentAppService)
        {
            _borrowAppService = borrowAppService;
            _bookAppService = bookAppService;
            _studentAppService = studentAppService;
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
            var books = await _bookAppService.GetAllBooks(); //bookID
            var students = await _studentAppService.GetAllStudents(); //studentID
            
            //ViewBag.Departments = departments;

            if (id != 0)
            {
                var borrow = await _borrowAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateBorrowViewModel()
                {
                    BorrowDate = borrow.BorrowDate,
                    ExpectedReturnDate = borrow.ExpectedReturnDate,
                    IsBorrowed = borrow.IsBorrowed,
                    ReturnDate = borrow.ReturnDate,
                    BookId = borrow.BookId,
                    BookTitle = borrow.BookTitle,
                    StudentId = borrow.StudentId,
                    StudentName = borrow.StudentName,
                    Id = id
                };
                //borrow.ExpectedReturnDate.AddDays(7);
            }

            
            model.ListBooks = books;
            model.ListStudents = students;
            //ViewBag.model = departments;

            return View(model);
        }      

        //[HttpGet]
        //public async Task <IActionResult> Return(int id)
        //{
        //    var model = new ReturnBorrowListViewModel();
        //    var books = await _bookAppService.GetAllBooks(); //bookID
        //    var students = await _studentAppService.GetAllStudents(); //studentID
        //                                                              //ViewBag.Departments = departments;

        //    if (id != 0)
        //    {
        //        var borrow = await _borrowAppService.GetAsync(new EntityDto<int>(id));
        //        model = new ReturnBorrowListViewModel()
        //        {
        //            BorrowDate = borrow.BorrowDate,
        //            ExpectedReturnDate = borrow.ExpectedReturnDate,
        //            IsBorrowed = borrow.IsBorrowed,
        //            ReturnDate = borrow.ReturnDate,
        //            BookId = borrow.BookId,
        //            BookTitle = borrow.BookTitle,
        //            StudentId = borrow.StudentId,
        //            StudentName = borrow.StudentName,
        //            Id = id
        //        };
        //    }

        //    model.ListBooks = books;
        //    model.ListStudents = students;
        //    //ViewBag.model = departments;

        //    return View(model);
        //}
    }
}
