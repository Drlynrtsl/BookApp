using BookApp.Books.Dto;
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
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public List<StudentDto> ListStudents { get; set; }
        //public DateTime BookYear { get; set; } 
        //public DateTime BookPublished { get; set; }
    }
}
