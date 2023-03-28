using Abp.Application.Services.Dto;
using BookApp.Authorization.Users;
using BookApp.Books;
using BookApp.Books.Dto;
using BookApp.Controllers;
using BookApp.Entities;
using BookApp.EntityFrameworkCore;
using BookApp.Web.Models.Book;
using BookApp.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            var books = await _bookAppService.GetAllAsync(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue});
            var model = new ListBookViewModel
            {
                Books = books.Items.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateBook(CreateBookViewModel model)
        //{
        //    //var currentUser = AbpSession.UserId;
        //    var bookDetails = new CreateBookDto
        //    {
        //        BookTitle = model.BookTitle,
        //        BookPublisher = model.BookPublisher,
        //        BookAuthor = model.BookAuthor
        //    };
        //    await _bookAppService.CreateAsync(bookDetails);

        //    return RedirectToAction("Index","Book");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]


        //public async Task<IActionResult> AddAsync(BookInfo addBook)
        //{
        //    var book = new BookInfo()
        //    {
        //        BookId = Guid.NewGuid(),
        //        BookTitle = addBook.BookTitle,
        //        BookAuthor = addBook.BookAuthor,
        //        BookPublisher = addBook.BookPublisher,
        //        DateAdded = addBook.DateAdded,
        //        AddedBy = addBook.AddedBy
        //    };

        //    string message = "Added new book successfully!";
        //    ViewBag.Message = message;

        //    await _bookAppService.(book);
        //    await _bookAppService.SaveChangesAsync();
        //    return RedirectToAction("Add");
        //}
    }

}
