namespace SimpleIdentity.Web.ViewModels
{

    using System.ComponentModel.DataAnnotations;
    public class UserViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Password { get; set; }
    }
}