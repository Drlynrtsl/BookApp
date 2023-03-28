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
    public class CreateBookDto
    {

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public string BookPublisher { get; set; }

        [Required]
        public string BookAuthor { get; set; }

    }
}
