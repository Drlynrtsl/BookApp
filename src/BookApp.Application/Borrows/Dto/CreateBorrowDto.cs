using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Borrows.Dto
{
    public class CreateBorrowDto
    {
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public DateTime ExpectedReturnDate { get; set; }
        [Required]
        public bool IsBorrowed { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int StudentId { get; set; }
        public int StudentName { get; set; }
    }
}
