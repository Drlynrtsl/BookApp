using Abp.Application.Services;
using BookApp.Books.Dto;
using BookApp.MultiTenancy.Dto;
using BookApp.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Books
{
    public interface IBookAppService : IAsyncCrudAppService<BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>
    {
        Task<List<BookDto>> GetAllBooks();
    }
}
