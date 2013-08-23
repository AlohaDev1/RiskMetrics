using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MetricsCorporation.Models
{
    public class LoginModel
    {
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
