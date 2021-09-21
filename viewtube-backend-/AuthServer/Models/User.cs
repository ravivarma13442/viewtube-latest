using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthServer
{
    public class User
    {
        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]  
        [StringLength(35, MinimumLength = 3)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]  
        [DataType(DataType.EmailAddress)]  
        [EmailAddress]
        [Display(Name = "Email address")]  
        [MaxLength(50)]  
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [MaxLength(10)]
        [MinLength(10)]
        public string  PhoneNumber { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Password is required")]  
        [StringLength(18, MinimumLength = 8)]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }



    }
}
