using ActitzLims.Blazor.Models;

namespace ActizLims.FrontBlazor.Services
{
    public interface IAmostraServiceBlazor
    {
        Task<bool> CadastrarAmostrasAsync(AmostraBlazor amostra, string token);
        Task<List<AmostraBlazor>> ObterAmostrasAsync(string usuarioId, string token);
        Task<bool> EditarAmostraAsync(AmostraBlazor amostra, string token);
        Task<bool> DeletarAmostraAsync(int id, string token);
    }
}
