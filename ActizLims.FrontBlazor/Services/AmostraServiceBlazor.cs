using ActitzLims.Blazor.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ActizLims.FrontBlazor.Services
{
    //Service para requisição nos endpoints da api Amostras
    public class AmostraServiceBlazor : IAmostraServiceBlazor
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AmostraServiceBlazor(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CadastrarAmostrasAsync(AmostraBlazor amostra, string token)
        {
            var client = _httpClientFactory.CreateClient("API");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsJsonAsync($"api/Home", amostra);
            return response.IsSuccessStatusCode;
        }
        public async Task<List<AmostraBlazor>> ObterAmostrasAsync(string usuarioId, string token)
        {
            var client = _httpClientFactory.CreateClient("API");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetFromJsonAsync<List<AmostraBlazor>>($"api/Home?idUser={usuarioId}");
            return response ?? new List<AmostraBlazor>();
        }

        public async Task<bool> EditarAmostraAsync(AmostraBlazor amostra, string token)
        {
            var client = _httpClientFactory.CreateClient("API");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PutAsJsonAsync($"api/Home/{amostra.Id}", amostra);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletarAmostraAsync(int id, string token)
        {
            var client = _httpClientFactory.CreateClient("API");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.DeleteAsync($"api/Home/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
