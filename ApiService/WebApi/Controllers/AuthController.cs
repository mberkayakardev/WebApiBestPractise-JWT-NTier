using Core.Dtos.Concrete;
using Core.Extentions.Concrete.Controller.Api;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace UdemyAuthServer.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CostumeApiController
    {
        private readonly ICostumeAuthenticationService _authenticationService;
        public AuthController(ICostumeAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }



        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var result = await _authenticationService.CreateTokenAsync(loginDto);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var result = await _authenticationService.CreateTokenByClient(clientLoginDto);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(string Token)
        {
            var result = await _authenticationService.RevokeRefreshToken(Token);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(string Token)
        {
            var result = await _authenticationService.CreateTokenByRefreshToken(Token);
            return ActionResultInstance(result);
        }
    }
}