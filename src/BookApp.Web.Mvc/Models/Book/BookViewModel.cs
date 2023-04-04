using System;

namespace BookApp.Web.Models.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string BookPublisher { get; set; }
        //public DateTime BookYear { get; set; } 
        //public DateTime BookPublished { get; set; }
    }
}
