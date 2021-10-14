using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using DevIO.Business.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        public async Task AdicionarAsync(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                && !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            return;
        }

        public async Task AtualizarAsync(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;
        }

        public async Task AtualizarEnderecoAsync(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;
        }

        public Task RemoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
