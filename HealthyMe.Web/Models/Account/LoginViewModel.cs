using System.ComponentModel.DataAnnotations;

namespace HealthyMe.Web.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}