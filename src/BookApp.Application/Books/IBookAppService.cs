using Abp.Application.Services;
using Abp.Application.Services.Dto;
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
        Task<List<BookDto>> GetAvailableBooks();
        Task<BookDto> GetBookWithBookCategories(EntityDto<int> input);
    }
}
