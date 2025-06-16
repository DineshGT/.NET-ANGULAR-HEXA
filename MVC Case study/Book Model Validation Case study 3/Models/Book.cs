using Book_Model_Validation_Case_study;
using Book_Model_Validation_Case_study.Utilities;
using System.ComponentModel.DataAnnotations;
namespace Book_Model_Validation_Case_study.Models
{
    public class Book
    {
        [Required(ErrorMessage = "ISBN is Required")]
        public int Isbn { get; set; }

        [Required(ErrorMessage = "Book name is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Book name must be 1 to 20 characters")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Author name must be 1 to 50 characters")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Published date is required")]
        [NotFutureDate(ErrorMessage = "Published date cannot be in the future")]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Book URL is required")]
        [Url(ErrorMessage = "Enter a valid URL")]
        public string BookUrl { get; set; }
    }
}
