using IdentityModel.Client;

namespace NewAPI.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
