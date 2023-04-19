﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
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
        //Task<PagedResultDto<BorrowDto>> GetAllPagedBorrowResult(PagedBorrowResultRequestDto input);
        Task<List<BorrowDto>> GetAllBorrows();
        Task<BorrowDto> GetBorrowWithBookAndStudent(EntityDto<int> input);

        //Task<BorrowDto> GetAsync(int input);
        //Task Update(BorrowDto input);
        //Task Create(CreateBorrowDto input);
    }
}