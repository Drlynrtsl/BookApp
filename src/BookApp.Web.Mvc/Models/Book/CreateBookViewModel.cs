using System.ComponentModel.DataAnnotations;

namespace BookApp.Web.Models.Book
{
    public class CreateBookViewModel
    {
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string BookAuthor { get; set; }
        [Required]
        public string BookPublisher { get; set; }
    }
}
