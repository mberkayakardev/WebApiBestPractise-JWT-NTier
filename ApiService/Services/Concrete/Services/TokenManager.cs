using ApiService.Entities.Concrete.AppEntities;
using AutoMapper;
using Core.Dtos.Concrete;
using Core.Utilities.Options.Api;
using Core.Utilities.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Services.Abstract.Base;
using Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Services.Concrete.Services
{
    public class TokenManager : BaseServices, ITokenService
    {
        private readonly CustomTokenOption _tokenOption;

        public TokenManager(IUnitOfWork unitOfWork, IMapper mapper, IOptions<CustomTokenOption> tokenOption) : base(unitOfWork, mapper)
        {
            _tokenOption = tokenOption.Value;
        }

        /// <summary>
        /// Create Refresh Token Method
        /// </summary>
        /// <returns></returns>
        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
        private IEnumerable<Claim> GetClaims(AppUser userApp, List<String> audiences) 
        {
            var userList = new List<Claim> 
            {
                new Claim(ClaimTypes.NameIdentifier,userApp.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, userApp.NormalizedUserEmail.ToString()),
                new Claim(ClaimTypes.Name,userApp.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            foreach (var ClaimItem in userApp.AppUserClaims.Select(x=> x.AppClaim))
            {
                userList.Add(new Claim(ClaimTypes.Role, ClaimItem.ClaimName));
            }

            foreach (var ClaimItem2 in userApp.AppUserRoles.Select(x => x.Role).SelectMany(x=> x.AppRoleClaims.Select(x=> x.AppClaims)))
            {
                userList.Add(new Claim(ClaimTypes.Role, ClaimItem2.ClaimName));
            }

            foreach(var ClaimItem3 in userApp.AppUserRoles.Select(x=> x.Role))
            {
                userList.Add(new Claim("BaseRole", ClaimItem3.RoleName));
            }


            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            return userList;
        }
        private IEnumerable<Claim> GetClaimsByClient(Client client)
        {
            var claims = new List<Claim>();
            claims.AddRange(client.Audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
            new Claim(JwtRegisteredClaimNames.Sub, client.Id.ToString());

            return claims;
        }


        public TokenDto CreateToken(AppUser userApp)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.RefreshTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOption.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                expires: accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: GetClaims(userApp, _tokenOption.Audience),
                 signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };

            return tokenDto;

        }
        public ClientTokenDto CreateTokenByClient(Client client)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);

            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOption.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                expires: accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: GetClaimsByClient(client),
                 signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new ClientTokenDto
            {
                AccessToken = token,

                AccessTokenExpiration = accessTokenExpiration,
            };

            return tokenDto;
        }
       
    }
}
