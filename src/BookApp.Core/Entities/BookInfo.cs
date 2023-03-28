using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Entities
{
    public class BookInfo: FullAuditedEntity<int>
    {
        public Guid BookId { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public string BookPublisher { get; set; }

        [Required]
        public string BookAuthor { get; set; }

        public DateTime DateAdded { get; set; }

        public string AddedBy { get; set; }    
    }
}
