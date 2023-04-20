using BookApp.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using BookApp.Departments.Dto;
using System.Collections.Generic;
using BookApp.Books.Dto;
using BookApp.Students.Dto;
using BookApp.BookCategories.Dto;

namespace BookApp.Web.Models.Borrow
{
    public class CreateBorrowViewModel
    {
        public int Id { get; set; } 
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public DateTime ExpectedReturnDate { get; set; }
        [Required]
        public bool IsBorrowed { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public List<BookDto> ListBooks { get; set; }
        [Required]
        public int StudentId  { get; set; }
        public string StudentName { get; set; }
        public int StudentDepartmentId { get; set; }
        public List<StudentDto> ListStudents { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<DepartmentDto> ListDepartments { get; set; }
        public int BookCategoriesId { get; set; }
        public string BookCategoriesName { get; set; }
        public List<BookCategoriesDto> ListBookCategories { get; set; }

    }
}
