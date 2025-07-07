using ActizLims.API.Data;
using ActizLims.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActizLims.API.Services
{
    public class AmostraService : IAmostraService
    {
        private readonly configDbContext _context;

        public AmostraService(configDbContext context)
        {
            _context = context;
        }
        
        //Parametro idUser para retornar apenas as amostras cadastradas do usuario que esta conectado
        public async Task<IEnumerable<Amostra>> GetAllAsync(int idUser)
        {
            return await _context.Amostras.Where(a => a.userId == idUser).ToListAsync();
        }

        public async Task<Amostra?> GetByIdAsync(int id, int idUser)
        {
            return await _context.Amostras.Where(a => a.userId == idUser && a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Amostra> CreateAsync(Amostra amostra)
        {
            _context.Amostras.Add(amostra);
            await _context.SaveChangesAsync();
            return amostra;
        }

        public async Task<bool> UpdateAsync(Amostra amostra)
        {
            var existente = await _context.Amostras.FindAsync(amostra.Id);
            if (existente == null) return false;

            existente.Codigo = amostra.Codigo;
            existente.Descricao = amostra.Descricao;
            existente.DataRecebimento = amostra.DataRecebimento;
            existente.Status = amostra.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var amostra = await _context.Amostras.FindAsync(id);
            if (amostra == null) return false;

            _context.Amostras.Remove(amostra);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Amostra>> GetFinalizadasUltimos30DiasAsync(int idUser)
        {
            //Retorno das amostras com Status 'Finalizada' cadastradas nos ultimos 30 dias para gerar relatório

            var inicio = DateTime.UtcNow.AddDays(-30);
            var fim = DateTime.UtcNow;

            return await _context.Amostras
                .Where(a => a.Status == StatusAmostra.Finalizada &&
                            a.DataRecebimento >= inicio &&
                            a.DataRecebimento <= fim && a.userId == idUser) 
                .ToListAsync();
        }
    }
}
