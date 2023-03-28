using System;

namespace BookApp.Web.Models.Book
{
    public class BookViewModel
    {
        public Guid BookID { get; set; }

        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string BookPublisher { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }
    }
}
