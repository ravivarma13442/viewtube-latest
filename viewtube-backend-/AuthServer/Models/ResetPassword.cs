using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AuthServer.Models
{
    public class ResetPassword
    {
        public string Email{ get; set;}

        [Required(ErrorMessage = "Old Password is required")]
        public string OldPassword{ get; set;}

        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword{ get; set;}
    }
}