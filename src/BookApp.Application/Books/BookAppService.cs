using Abp.Application.Services;
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
        private readonly IRepository<BookCategory, int> _bookCategoryRepository;
        private readonly IRepository<Department, int> _departmentRepository;
        public BookAppService(IRepository<BookInfo, int> repository, IRepository<BookCategory, int> bookCategoryRepository, IRepository<Department, int> departmentRepository) : base(repository)
        {
            _repository = repository;
            _bookCategoryRepository = bookCategoryRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            var query = await _repository.GetAll().Select(x => ObjectMapper.Map<BookDto>(x)).ToListAsync();
            return query;
        }

        public async Task<List<BookDto>> GetAvailableBooks()
        {
            var query = await _repository.GetAll()
                .Where(x => !x.IsBorrowed)
                .Select(x => ObjectMapper.Map<BookDto>(x))
                .ToListAsync();
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

        public override async Task<PagedResultDto<BookDto>> GetAllAsync(PagedBookResultRequestDto input)
        {
            var query = await _repository.GetAll()
            .Include(x => x.BookCategories)
            .Select(x => ObjectMapper.Map<BookDto>(x))
            .ToListAsync();
            return new PagedResultDto<BookDto>(query.Count(), query);
        }

        public async Task<BookDto> GetBookWithBookCategories(EntityDto<int>input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.BookCategories)
                //.ThenInclude(BookCategories => BookCategories.DepartmentId)
                .Where(x => x.Id == input.Id)
                .Select(x => ObjectMapper.Map<BookDto>(x))
                .FirstOrDefaultAsync();

            return query;
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
