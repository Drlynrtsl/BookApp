using System.ComponentModel.DataAnnotations;

namespace BookApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}