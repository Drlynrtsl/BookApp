using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using BookApp.Borrows.Dto;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookApp.Students.Dto;

namespace BookApp.Borrows
{
    public class BorrowAppService : AsyncCrudAppService<Borrow, BorrowDto, int, PagedBorrowResultRequestDto, CreateBorrowDto, BorrowDto>, IBorrowAppService
    {
        private readonly IRepository<Borrow, int> _repository;
        public BorrowAppService(IRepository<Borrow, int> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<BorrowDto>> GetAllBorrows()
        {
            var query = await _repository.GetAll().Select(x => ObjectMapper.Map<BorrowDto>(x)).ToListAsync();
            return query;
        }

        public async Task<PagedResultDto<BorrowDto>> GetAllAsync(PagedBorrowResultRequestDto input)
        {
            var query = await _repository.GetAll()
                
                .Include(x => x.Book)
                .Include(x => x.Student)
                //.ThenInclude(x => x.StudentDepartment)
                .Select(x => ObjectMapper.Map<BorrowDto>(x))
                .ToListAsync();
            return new PagedResultDto<BorrowDto>(query.Count(), query);
        }

        public override Task<BorrowDto> CreateAsync(CreateBorrowDto input)
        {
            try
            {
                return base.CreateAsync(input);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }


        public override Task<BorrowDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BorrowDto> UpdateAsync(BorrowDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Borrow> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
    }
}
