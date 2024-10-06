namespace CraftIQ.Models
{
    public interface IAuthService
    {
        Task<AuthModel> Register(RegisterModel model);
        Task<AuthModel> GetToken(LoginModel model);
    }
}
