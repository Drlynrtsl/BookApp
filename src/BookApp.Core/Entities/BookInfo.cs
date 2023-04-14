using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Entities
{
    public class BookInfo: FullAuditedEntity<int>
    {
        [Required]
        public string BookTitle { get; set; }

        [Required]
        public string BookPublisher { get; set; }

        [Required]
        public string BookAuthor { get; set; }

        public int? StudentId { get; set; }
        public Student Student { get; set; }

        //[Required]
        //public DateTime BookYear { get; set; }

        //[Required]
        //public DateTime BookPublished { get; set; }

        //public Borrow BorrowBook { get; set; }

    }
}
