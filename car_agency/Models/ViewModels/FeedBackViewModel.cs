using System.ComponentModel.DataAnnotations;

namespace car_agency.Models.ViewModels
{
    public class FeedBackViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FeedBack { get; set; }
        [Required]
        public string Subject { get; set; }
        public string? UserId { get; set; }
    }
}
