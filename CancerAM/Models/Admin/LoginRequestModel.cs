using System.ComponentModel.DataAnnotations;

namespace CancerAM.Models.Admin
{
    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}