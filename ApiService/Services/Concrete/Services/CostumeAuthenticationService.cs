using ApiService.Entities.Concrete.AppEntities;
using AutoMapper;
using Core.Dtos.Concrete;
using Core.Utilities.Results.MVC.BaseResult;
using Entities.Concrete.AppEntities;
using Microsoft.Extensions.Options;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Services.Abstract.Base;
using QuizApp.Services.Concrete.Messages;
using Services.Abstract;
using TrendMusic.ECommerce.Core.Utilities.Security.HashHelper;

namespace Services.Concrete.Services
{
    public class CostumeAuthenticationService : BaseServices, ICostumeAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        public CostumeAuthenticationService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<List<Client>> clients, ITokenService tokenService) : base(unitOfWork, mapper)
        {
            _clients = clients.Value;
            _tokenService = tokenService;
        }

        public async Task<IApiDataResult<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null)
                return new ApiDataResult<TokenDto>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.BadRequest, Messages.User.BosBilgileriHatali);

            var AppUserRepository = _unitOfWork.GetGenericRepositories<AppUser>();

            var AppUser = await AppUserRepository.GetAsync(x => x.NormalizedUserEmail == loginDto.Email && x.IsActive == true);
            if (AppUser == null)
                return new ApiDataResult<TokenDto>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.BadRequest, Messages.User.GirisBilgileriHatali);

            if (AppUser.PasswordHash != HashHelper.CreateSha256Hash(loginDto.Password))
            {
                AppUser.FalseEntryCount++;
                AppUser.IsBlocked = AppUser.FalseEntryCount == 5 ? true : false;
                   await _unitOfWork.SaveChangesAsync();
                return new ApiDataResult<TokenDto>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.BadRequest, Messages.User.GirisBilgileriHatali);
            }

            if (AppUser.IsBlocked)
            {
                return new ApiDataResult<TokenDto>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.BadRequest, Messages.User.KullaniciKilitli);
            }

            var token = _tokenService.CreateToken(AppUser);

            var userRefreshToken = await _unitOfWork.GetGenericRepositories<AppToken>().GetAsync(x => x.AppUserId == AppUser.Id);
            if (userRefreshToken == null)
            {
                await _unitOfWork.GetGenericRepositories<AppToken>().CreateAsync(new AppToken { Id = 1, IsActive = true, CreatedUserId = AppUser.Id, ModifiedUserId = AppUser.Id, IsUsed = false, CreatedUserName = AppUser.UserName, ModifiedUserName = AppUser.UserName, AppUserId = AppUser.Id, RefreshToken = token.RefreshToken, ExpireDate = token.RefreshTokenExpiration });
            }
            else
            {
                userRefreshToken.RefreshToken = token.RefreshToken;
                userRefreshToken.ExpireDate = token.RefreshTokenExpiration;
            }

            await _unitOfWork.SaveChangesAsync();

            return new ApiDataResult<TokenDto>(token, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.Ok);
        }

        public async Task<IApiDataResult<ClientTokenDto>> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientLoginDto.ClientId && x.Secret == clientLoginDto.ClientSecret);

            if (client == null)
            {
                return new ApiDataResult<ClientTokenDto>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.NotFound);
            }

            var token = _tokenService.CreateTokenByClient(client);

            return new ApiDataResult<ClientTokenDto>(token, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.NotFound);


        }

        public async Task<IApiDataResult<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {

            var userRefreshToken = await _unitOfWork.GetGenericRepositories<AppToken>().GetAsync(x => x.RefreshToken == refreshToken);
            if (userRefreshToken == null)
            {
                return new ApiDataResult<TokenDto>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.NotFound);

            }


            var AppUser = await _unitOfWork.GetGenericRepositories<AppUser>().GetAsync(x => x.Id == userRefreshToken.AppUserId);
            if (AppUser == null)
                return new ApiDataResult<TokenDto>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.BadRequest, Messages.User.GirisBilgileriHatali);

            var tokenDto = _tokenService.CreateToken(AppUser);

            userRefreshToken.RefreshToken = tokenDto.RefreshToken;
            userRefreshToken.ExpireDate = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.SaveChangesAsync();

            return new ApiDataResult<TokenDto>(tokenDto, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.Ok);


        }

        public async Task<IApiResult> RevokeRefreshToken(string refreshToken)
        {
            var userRefreshToken = await _unitOfWork.GetGenericRepositories<AppToken>().GetAsync(x => x.RefreshToken == refreshToken);
            if (userRefreshToken == null)
            {
                return new ApiDataResult<TokenDto>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.NotFound);
            }

            await _unitOfWork.GetGenericRepositories<AppToken>().DeleteAsync(userRefreshToken);
            await _unitOfWork.SaveChangesAsync();

            return new ApiDataResult<TokenDto>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.Ok);

        }
    }
}
