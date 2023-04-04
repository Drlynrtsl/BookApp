using Abp.Application.Services.Dto;
using BookApp.Books;
using BookApp.Books.Dto;
using BookApp.Controllers;
using BookApp.Web.Models.Book;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace BookApp.Web.Host.Controllers
{
    public class BookController : BookAppControllerBase
    {
        private readonly IBookAppService _bookAppService;
        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
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

            if (id != 0)
            {
                var book = await _bookAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateBookViewModel()
                {
                    BookTitle = book.BookTitle,
                    BookAuthor = book.BookAuthor,
                    BookPublisher = book.BookPublisher,
                    //BookYear = book.BookYear,
                    //BookPublished = book.BookPublished,
                    Id = id
                };
            }

            

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
