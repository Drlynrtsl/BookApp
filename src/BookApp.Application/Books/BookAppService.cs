﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using BookApp.Books.Dto;
using BookApp.Borrows.Dto;
using BookApp.Departments.Dto;
using BookApp.Editions;
using BookApp.Entities;
using BookApp.MultiTenancy;
using BookApp.MultiTenancy.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Books
{
    public class BookAppService : AsyncCrudAppService<BookInfo, BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>, IBookAppService
    {
        private readonly IRepository<BookInfo, int> _repository;
        public BookAppService(IRepository<BookInfo, int> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            var query = await _repository.GetAll().Select(x => ObjectMapper.Map<BookDto>(x)).ToListAsync();
            return query;
        }

        public override Task<BookDto> CreateAsync(CreateBookDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public async Task<PagedResultDto<BookDto>> GetAllAsync(PagedBookResultRequestDto input)
        {
            var query = await _repository.GetAll()

            .Include(x => x.Student)
            .Select(x => ObjectMapper.Map<BookDto>(x))
            .ToListAsync();
            return new PagedResultDto<BookDto>(query.Count(), query);
        }


        public override Task<BookDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BookDto> UpdateAsync(BookDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<BookInfo> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
    }

  
}
