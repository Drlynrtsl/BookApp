using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookApp.Books.Dto;
using BookApp.Borrows.Dto;
using BookApp.Departments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Borrows
{
    public interface IBorrowAppService : IAsyncCrudAppService<BorrowDto, int, PagedBorrowResultRequestDto, CreateBorrowDto, BorrowDto>
    {
        Task<List<BorrowDto>> GetAllBorrows();
        Task<BorrowDto> GetBorrowWithBookAndStudentUnderBookCategory(EntityDto<int> input);
        Task<BorrowDto> CreateAsync(CreateBorrowDto input);
        Task<BorrowDto> UpdateAsync(BorrowDto input);
        Task<List<BookDto>> GetAllBooksByStudentId(int id);
    }
}
