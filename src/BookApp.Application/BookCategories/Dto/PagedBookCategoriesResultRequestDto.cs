using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.BookCategories.Dto
{
    public class PagedBookCategoriesResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
