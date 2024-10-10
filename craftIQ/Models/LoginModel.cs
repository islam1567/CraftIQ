using System.ComponentModel.DataAnnotations;

namespace CraftIQ.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
