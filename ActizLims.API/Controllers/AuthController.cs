using ActizLims.API.Models;
using ActizLims.API.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ActizLims.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        //Controller de autenticação

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User request)
        {
            var response = _authService.Authenticate(request.usuario, request.senha);
            if (response == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos." });

            return Ok(new { Token = response.Token, Nome = response.Nome, Id = response.Id });
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastrarUsuario(User user)
        {
            var created = await _authService.CadastrarUsuario(user);
            return Ok(new { usuario = created});
        }
    }
}
