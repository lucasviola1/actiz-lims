using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ActizLims.API.Data;
using ActizLims.API.Services;
using ActizLims.API.Models;

namespace ActizLims.Tests
{
    public class AdicionarAmostraService
    {
        private configDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<configDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            return new configDbContext(options);
        }

        [Fact]
        public async Task Deve_Adicionar_Amostra_Com_Sucesso()
        {
            var context = GetInMemoryDbContext();
            var service = new AmostraService(context);

            var novaAmostra = new Amostra
            {
                Codigo = "AM123",
                Descricao = "Amostra de Teste",
                DataRecebimento = DateTime.Now,
                Status = StatusAmostra.Pendente,
                userId = 1
            };

            await service.CreateAsync(novaAmostra);
            var amostras = await service.GetAllAsync(1);

            Assert.Single(amostras);
            Assert.Equal("AM123", amostras.First().Codigo);
        }
    }
}
