using Abp.Application.Services.Dto;
using BookApp.Books.Dto;
using System.Collections.Generic;

namespace BookApp.Web.Models.Book
{
    public class ListBookViewModel
    {
        public List<BookDto> Books { get; set; }
    }
}