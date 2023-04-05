using Abp.Application.Services;
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
    }
}
