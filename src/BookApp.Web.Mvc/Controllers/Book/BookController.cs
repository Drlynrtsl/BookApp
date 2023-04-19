using Abp.Application.Services.Dto;
using BookApp.BookCategories;
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
        private readonly IBookCategoriesAppService _bookCategoriesAppService;
        public BookController(IBookAppService bookAppService, IBookCategoriesAppService bookCategoriesAppService)
        {
            _bookAppService = bookAppService;
            _bookCategoriesAppService = bookCategoriesAppService;
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
            var bookcategories = await _bookCategoriesAppService.GetAllBookCategories();

            if (id != 0)
            {
                var book = await _bookAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateBookViewModel()
                {
                    BookTitle = book.BookTitle,
                    BookAuthor = book.BookAuthor,
                    BookPublisher = book.BookPublisher,
                    IsBorrowed = book.IsBorrowed,
                    BookCategoriesId = book.BookCategoriesId,
                    Id = id
                };
            }

            model.ListBookCategories = bookcategories;


            return View(model);
        }

    }

}
