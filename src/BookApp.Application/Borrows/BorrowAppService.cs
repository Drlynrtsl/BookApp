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
using System.Net.Http.Headers;

namespace BookApp.Borrows
{
    public class BorrowAppService : AsyncCrudAppService<Borrow, BorrowDto, int, PagedBorrowResultRequestDto, CreateBorrowDto, BorrowDto>, IBorrowAppService
    {
        private readonly IRepository<Borrow, int> _repository;
        private readonly IRepository<BookInfo, int> _bookRepository;
        public BorrowAppService(IRepository<Borrow, int> repository, IRepository<BookInfo, int> bookRepository) : base(repository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }

        public async Task<List<BorrowDto>> GetAllBorrows()
        {
            var query = await _repository.GetAll().Select(x => ObjectMapper.Map<BorrowDto>(x)).ToListAsync();
            return query;
        }

        public override async Task<PagedResultDto<BorrowDto>> GetAllAsync(PagedBorrowResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.Book)
                .Include(x => x.Student)
                .Select(x => ObjectMapper.Map<BorrowDto>(x))
                .ToListAsync();
            return new PagedResultDto<BorrowDto>(query.Count(), query);
        }

        public override async Task<BorrowDto> CreateAsync(CreateBorrowDto input)
        {
            try
            {
                var borrow = ObjectMapper.Map<Borrow>(input);
                await _repository.InsertAsync(borrow);

                var book = await _bookRepository.GetAsync(input.BookId);
                book.IsBorrowed = true;
                
                await _bookRepository.UpdateAsync(book);

                return base.MapToEntityDto(borrow);
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


        public async Task<BorrowDto> GetBorrowWithBookAndStudent(EntityDto<int> input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.Book)
                .Include(x => x.Student)
                //.ThenInclude(Student => Student.StudentDepartmentId)
                .Include(x => x.Department)
                //.ThenInclude(Department => Department.Id)
                .Where(x => x.Id == input.Id)
                //.Where(x => Student.StudentDepartmentId == Department.Id)
                .Select(x => ObjectMapper.Map<BorrowDto>(x))
                .FirstOrDefaultAsync();

            return query;
        }

       

        //public override Task<BorrowDto> GetAsync(EntityDto<int> input)
        //{
        //    return base.GetAsync(input);
        //}
        public override async Task<BorrowDto> UpdateAsync(BorrowDto input)
        {
            try
            {
                var borrow = ObjectMapper.Map<Borrow>(input);
                await _repository.UpdateAsync(borrow);

                var book = await _bookRepository.GetAsync(input.BookId);
                if (input.ReturnDate.HasValue)
                { 
                    book.IsBorrowed = false; 
                }
                
                await _bookRepository.UpdateAsync(book);

                return base.MapToEntityDto(borrow);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        protected override Task<Borrow> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }

  
    }
}
