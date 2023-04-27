using BookApp.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using BookApp.Students.Dto;
using System.Collections.Generic;
using BookApp.Borrows.Dto;
using BookApp.Departments.Dto;
using BookApp.Authorization.Users;
using BookApp.Roles.Dto;
using BookApp.BookCategories.Dto;

namespace BookApp.Web.Models.Borrow
{
    public class BorrowListViewModel
    {
        public List<BorrowDto> Borrows { get; set; }
        public List<BookCategoriesDto> BookCategories { get; set; }
    }
}
