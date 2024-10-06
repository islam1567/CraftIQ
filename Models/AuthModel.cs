namespace CraftIQ.Models
{
    public class AuthModel
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsAuthentecated { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
