using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Borrows.Dto
{
    [AutoMapTo(typeof(Borrow))]
    [AutoMapFrom(typeof(Borrow))]
    public class BorrowDto : EntityDto<int>
    {
        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public BookInfo Book { get; set; }
        public int StudentId { get; set; }
        public int StudentName { get; set; }
        public Student Student { get; set; }
    }
}
