using ActizLims.FrontBlazor.Models;

namespace ActizLims.FrontBlazor.Services
{
    public interface IAuthServiceBlazor
    {
        Task<AuthResponseBlazor> Login(UserBlazor user);

        Task<bool> CadastrarUsuariosAsync(UserBlazor user);
    }
}
