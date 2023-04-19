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

        [Required]
        public bool IsBorrowed { get; set; }

        public int? BookCategoriesId { get; set; }

        public BookCategory BookCategories { get; set; }

    }
}
