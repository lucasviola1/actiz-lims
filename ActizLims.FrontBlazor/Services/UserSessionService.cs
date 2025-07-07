using Microsoft.JSInterop;

namespace ActizLims.FrontBlazor.Services
{
    public class UserSessionService
    {
        private readonly IJSRuntime _js;

        public UserSessionService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<string?> GetTokenAsync()
            => await _js.InvokeAsync<string>("localStorage.getItem", "jwt_token");

        public async Task<string?> GetUserNameAsync()
            => await _js.InvokeAsync<string>("localStorage.getItem", "usuario_nome");

        public async Task<string?> GetUserIdAsync()
            => await _js.InvokeAsync<string>("localStorage.getItem", "usuario_id");
    }
}
