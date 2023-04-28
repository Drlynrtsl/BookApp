using BookApp.BookCategories.Dto;
using BookApp.Books.Dto;
using BookApp.Departments.Dto;
using BookApp.Students.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Web.Models.Book
{
    public class CreateBookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string BookAuthor { get; set; }
        [Required]
        public string BookPublisher { get; set; }
        [Required]
        public bool IsBorrowed { get; set; }        
        public int BookCategoriesId { get; set; }
        public string BookCategoriesName { get; set; }
        public List<BookCategoriesDto> ListBookCategories { get; set; }
    }
}
