using ActizLims.API.Models;

namespace ActizLims.API.Services
{
    public interface IAmostraService
    {
        Task<IEnumerable<Amostra>> GetAllAsync(int idUser);
        Task<Amostra?> GetByIdAsync(int id, int idUser);
        Task<Amostra> CreateAsync(Amostra amostra);
        Task<bool> UpdateAsync(Amostra amostra);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Amostra>> GetFinalizadasUltimos30DiasAsync(int idUser);
    }
}
