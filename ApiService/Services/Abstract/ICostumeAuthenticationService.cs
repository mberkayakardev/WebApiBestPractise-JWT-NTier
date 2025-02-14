using Core.Dtos.Concrete;
using Core.Utilities.Results.MVC.BaseResult;
using QuizApp.Services.Abstract.Base;

namespace Services.Abstract
{
    public interface ICostumeAuthenticationService : IBaseServices
    {
        Task<IApiDataResult<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<IApiDataResult<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<IApiResult> RevokeRefreshToken(string refreshToken);
        Task<IApiDataResult<ClientTokenDto>> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}
