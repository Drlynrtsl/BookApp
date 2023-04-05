using BookApp.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using BookApp.Students.Dto;
using System.Collections.Generic;
using BookApp.Borrows.Dto;

namespace BookApp.Web.Models.Borrow
{
    public class BorrowListViewModel
    {
        public List<BorrowDto> Borrows { get; set; }
    }
}
