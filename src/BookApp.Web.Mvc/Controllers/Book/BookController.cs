using Abp.Application.Services.Dto;
using BookApp.Books;
using BookApp.Books.Dto;
using BookApp.Controllers;
using BookApp.Students;
using BookApp.Web.Models.Book;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;


namespace BookApp.Web.Host.Controllers
{
    public class BookController : BookAppControllerBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IStudentAppService _studentAppService;
        public BookController(IBookAppService bookAppService, IStudentAppService studentAppService)
        {
            _bookAppService = bookAppService;
            _studentAppService = studentAppService;
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }


        public async Task<IActionResult> Index()
        {
            
            var books = await _bookAppService.GetAllAsync(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new ListBookViewModel
            {
                Books = books.Items.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var model = new CreateBookViewModel();
            var students = await _studentAppService.GetAllStudents();

            if (id != 0)
            {
                var book = await _bookAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateBookViewModel()
                {
                    BookTitle = book.BookTitle,
                    BookAuthor = book.BookAuthor,
                    BookPublisher = book.BookPublisher,
                    StudentId = book.StudentId,
                    StudentName = book.StudentName,
                    Id = id
                };
            }


            model.ListStudents = students;
            return View(model);
        }

        //[HttpPost]

        //public async Task <IActionResult> Update(int id)
        //{
        //    var model = new CreateBookViewModel();

        //    if (id != 0)
        //    {
        //        var book = await _bookAppService.GetAsync(new EntityDto<int>(id));
        //        model = new CreateBookViewModel()
        //        {
        //            BookTitle = book.BookTitle,
        //            BookAuthor = book.BookAuthor,
        //            BookPublisher = book.BookPublisher,
        //            Id = id
        //        };
        //    }

        //    return View(model);
        //}
    }

}
