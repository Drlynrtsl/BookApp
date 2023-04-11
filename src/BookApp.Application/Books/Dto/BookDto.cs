using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookApp.Entities;
using System;

namespace BookApp.Books.Dto
{
    [AutoMapTo(typeof(BookInfo))]
    [AutoMapFrom(typeof(BookInfo))]
    public class BookDto: EntityDto<int>
    {
        public string BookTitle { get; set; }
        public string BookPublisher { get; set; }
        public string BookAuthor { get; set; }
        public bool IsBorrowed { get; set; }
        //public DateTime ReturnDate {get; set; }
    }
}
