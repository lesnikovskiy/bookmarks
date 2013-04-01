using System.ComponentModel.DataAnnotations;

namespace Bookmarks.Models
{
    public class Bookmark
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(255)]
        public string Title { get; set; }

        [Display(Name = "URL")]
        [Required(ErrorMessage = "URL is required")]
        [RegularExpression(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w-./?%&=])?$", ErrorMessage = "Enter URL in correct format!")]
        public string Url { get; set; }
    }
}