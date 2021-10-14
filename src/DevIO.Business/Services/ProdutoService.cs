using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using DevIO.Business.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        public async Task AdicionarAsync(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
        }

        public async Task AtualizarAsync(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
        }

        public Task RemoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
