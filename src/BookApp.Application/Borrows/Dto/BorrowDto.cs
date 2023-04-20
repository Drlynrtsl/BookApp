using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookApp.Books.Dto;
using BookApp.Departments.Dto;
using BookApp.Entities;
using BookApp.Students.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Borrows.Dto
{
    [AutoMapTo(typeof(Borrow))]
    [AutoMapFrom(typeof(Borrow))]
    public class BorrowDto : EntityDto<int>
    {
        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public BookDto Book { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentDepartmentId { get; set; }
        public StudentDto Student { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
