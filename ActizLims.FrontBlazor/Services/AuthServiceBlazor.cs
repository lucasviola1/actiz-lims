using ActitzLims.Blazor.Models;
using ActizLims.FrontBlazor.Models;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ActizLims.FrontBlazor.Services
{
    //Service para login e cadastro de usuarios
    public class AuthServiceBlazor : IAuthServiceBlazor
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IJSRuntime _js;
        public AuthServiceBlazor(IHttpClientFactory httpClientFactory, IJSRuntime js)
        {
            _httpClientFactory = httpClientFactory;
            _js = js;
        }
        public async Task<AuthResponseBlazor> Login(UserBlazor user)
        {
            var client = _httpClientFactory.CreateClient("API");

            var response = await client.PostAsJsonAsync("api/Auth/login", user);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<AuthResponseBlazor>();

                if (data is not null)
                {
                    // Armazena no localStorage
                    await _js.InvokeVoidAsync("localStorage.setItem", "jwt_token", data.Token);
                    await _js.InvokeVoidAsync("localStorage.setItem", "usuario_nome", data.Nome);
                    await _js.InvokeVoidAsync("localStorage.setItem", "usuario_id", data.Id);

                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                var mensagem = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro ao buscar dados: {response.StatusCode} - {mensagem}");
            }
        }

        public async Task<bool> CadastrarUsuariosAsync(UserBlazor user)
        {
            var client = _httpClientFactory.CreateClient("API");

            var response = await client.PostAsJsonAsync("api/Auth/cadastro", user);

            return response.IsSuccessStatusCode;
        }
    }
}
