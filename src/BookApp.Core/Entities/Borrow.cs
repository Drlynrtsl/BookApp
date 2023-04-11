using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Entities
{
    public class Borrow : FullAuditedEntity<int>
    {
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public bool IsBorrowed { get; set; }
        public int? BookId { get; set; }
        public BookInfo Book { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
