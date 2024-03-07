using System.ComponentModel.DataAnnotations;

namespace portfolio.Models
{
    public class loginmodel
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
