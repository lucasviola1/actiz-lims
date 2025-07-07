using ActizLims.API.Models;

namespace ActizLims.API.Services
{
    public interface IAuthService
    {
        AuthResponse? Authenticate(string username, string password);

        Task<User> CadastrarUsuario(User user);
    }
}
