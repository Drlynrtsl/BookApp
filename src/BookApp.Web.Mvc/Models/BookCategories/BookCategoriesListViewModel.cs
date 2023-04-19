using BookApp.BookCategories.Dto;
using BookApp.Borrows.Dto;
using System.Collections.Generic;

namespace BookApp.Web.Models.BookCategories
{
    public class BookCategoriesListViewModel
    {
        public List<BookCategoriesDto> BookCategories { get; set; }
    }
}
