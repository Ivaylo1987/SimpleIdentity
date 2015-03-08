namespace SimpleIdentity.Models
{
    using SimpleIdentity.Models.Contracts;
    using System.ComponentModel.DataAnnotations;
    public class User : IUser
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}