using Abp.AutoMapper;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.BookCategories.Dto
{
    [AutoMapTo(typeof(BookCategory))]
    public class CreateBookCategoriesDto
    {
        [Required]
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
