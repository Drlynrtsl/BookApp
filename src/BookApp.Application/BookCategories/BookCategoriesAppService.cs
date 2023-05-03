using Abp.Application.Services;
using BookApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using BookApp.BookCategories.Dto;
using Microsoft.EntityFrameworkCore;

namespace BookApp.BookCategories
{
    public class BookCategoriesAppService : AsyncCrudAppService<BookCategory, BookCategoriesDto, int, PagedBookCategoriesResultRequestDto, CreateBookCategoriesDto, BookCategoriesDto>, IBookCategoriesAppService
    {
        private readonly IRepository<BookCategory, int> _repository;

        public BookCategoriesAppService(IRepository<BookCategory, int> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<BookCategoriesDto>> GetAllBookCategories()
        {
            var query = await _repository.GetAll()
                .Select(x => ObjectMapper.Map<BookCategoriesDto>(x))
                .ToListAsync();
            return query;
        }

        public override Task<BookCategoriesDto> CreateAsync(CreateBookCategoriesDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override async Task<PagedResultDto<BookCategoriesDto>> GetAllAsync(PagedBookCategoriesResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.Department)
                .Select(x => ObjectMapper.Map<BookCategoriesDto>(x))
                .ToListAsync();
            return new PagedResultDto<BookCategoriesDto>(query.Count(), query);
        }

        public override Task<BookCategoriesDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BookCategoriesDto> UpdateAsync(BookCategoriesDto input)
        {
            return base.UpdateAsync(input);
        }
    }
}
