using Abp.Application.Services;
using BookApp.Borrows.Dto;
using BookApp.Borrows;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Application.Services.Dto;
using BookApp.Departments.Dto;

namespace BookApp.BookCategories.Dto
{
    [AutoMapTo(typeof(BookCategory))]
    [AutoMapFrom(typeof(BookCategory))]
    public class BookCategoriesDto : EntityDto <int>
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
