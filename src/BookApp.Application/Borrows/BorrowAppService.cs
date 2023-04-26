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
using BookApp.Books.Dto;

namespace BookApp.Borrows
{
    public class BorrowAppService : AsyncCrudAppService<Borrow, BorrowDto, int, PagedBorrowResultRequestDto, CreateBorrowDto, BorrowDto>, IBorrowAppService
    {
        private readonly IRepository<Borrow, int> _repository;
        private readonly IRepository<BookInfo, int> _bookRepository;
        private readonly IRepository<BookCategory, int> _bookCategoryRepository;
        private readonly IRepository<Student, int> _studentRepository;
        public BorrowAppService(IRepository<Borrow, int> repository, IRepository<BookInfo, int> bookRepository, IRepository<BookCategory, int> bookCategoryRepository, IRepository<Student, int> studentRepository) : base(repository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
            _bookCategoryRepository = bookCategoryRepository;
            _studentRepository = studentRepository;
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
                    .ThenInclude(x => x.BookCategories)
                    .ThenInclude(x => x.Department)
                .Include(x => x.Student)
                    .ThenInclude(x => x.StudentDepartment)
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
                var student = await _studentRepository.GetAsync(input.StudentId);
                var bookcategory = await _bookCategoryRepository.GetAsync(input.BookCategoriesId);
                book.IsBorrowed = true;

                if (input.StudentDepartmentId == bookcategory.DepartmentId)
                {
                    book.BookCategoriesId = bookcategory.Id;
                }
                
                await _bookRepository.UpdateAsync(book);
                await _studentRepository.UpdateAsync(student);
                await _bookCategoryRepository.UpdateAsync(bookcategory);

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

        public async Task<BorrowDto> GetBorrowWithBookAndStudentUnderBookCategory(EntityDto<int> input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.Book)
                    .ThenInclude(x => x.BookCategories)
                    .ThenInclude(x => x.Department)
                .Include(x => x.Student)
                    .ThenInclude(x => x.StudentDepartment)
                .Where(x => x.Id == input.Id)
                .Select(x => ObjectMapper.Map<BorrowDto>(x))
                .FirstOrDefaultAsync();

            return query;
        }

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

        protected override BorrowDto MapToEntityDto(Borrow entity)
        {
            return base.MapToEntityDto(entity);
        }

        protected override void MapToEntity(BorrowDto updateInput, Borrow entity)
        {
            base.MapToEntity(updateInput, entity);
        }

        public async Task<List<BookDto>> GetAllBooksByStudentId(int id)
        {
            var query = await _repository.GetAll()
                .Include(x => x.Student)
                .Select(x => ObjectMapper.Map<BookDto>(x))
                .ToListAsync();
            return query;
        }
    }
}
