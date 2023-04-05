using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Entities
{
    public class Return : FullAuditedEntity<int>
    {
        public int BorrowId { get; set; }
        public DateTime ExpectedReturnDate { get; set; }

    }
}
