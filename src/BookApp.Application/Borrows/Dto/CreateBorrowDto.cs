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
    public class CreateBorrowDto
    {
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public DateTime ExpectedReturnDate { get; set; }    
        public DateTime? ReturnDate { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
}
