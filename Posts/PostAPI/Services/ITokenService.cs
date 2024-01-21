using IdentityModel.Client;

namespace PostAPI.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
