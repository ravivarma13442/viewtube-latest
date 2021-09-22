using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AuthServer.Models
{
    public class ForgetPassword
    {
        public string Email{ get; set;}


        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword{ get; set;}
    }
}