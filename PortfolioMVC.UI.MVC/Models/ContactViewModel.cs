using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Display(Name = "Your Name")]
        [Required(ErrorMessage = "*Name is required")]
        public string Name { get; set; }

        [Display(Name = "Your Email")]
        [Required(ErrorMessage = "*Email address is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "*Subject is required")]
        public string Subject { get; set; }

        [Display(Name= "Message...")]
        [Required(ErrorMessage = "*Message is required")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
