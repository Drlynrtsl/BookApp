using Abp.Application.Services;
using BookApp.BookCategories.Dto;
using BookApp.Borrows.Dto;
using BookApp.Departments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.BookCategories
{
    public interface IBookCategoriesAppService : IAsyncCrudAppService<BookCategoriesDto, int, PagedBookCategoriesResultRequestDto, CreateBookCategoriesDto, BookCategoriesDto>
    {
        Task<List<BookCategoriesDto>> GetAllBookCategories();
    }
    
}
