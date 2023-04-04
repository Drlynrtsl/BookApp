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
        [Required]
        public string BookTitle { get; set; }

        [Required]
        public string BookPublisher { get; set; }

        [Required]
        public string BookAuthor { get; set; }

        //[Required]
        //public DateTime BookYear { get; set; }

        //[Required]
        //public DateTime BookPublished { get; set; }
    }
}
