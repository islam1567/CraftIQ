using System.ComponentModel.DataAnnotations;

namespace CraftIQ.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
