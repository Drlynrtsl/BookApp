using BookApp.BookCategories.Dto;
using BookApp.Books.Dto;
using BookApp.Departments.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Web.Models.BookCategories
{
    public class CreateBookCategoriesViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public List<DepartmentDto> ListDepartments { get; set; }
    }
}
