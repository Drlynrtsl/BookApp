using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Books.Dto
{
    [AutoMapTo(typeof(BookInfo))]
    [AutoMapFrom(typeof(BookInfo))]
    public class BookDto: EntityDto<int>
    {
        public string BookTitle { get; set; }
        public string BookPublisher { get; set; }
        public string BookAuthor { get; set; }
    }
}
