using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services.Interfaces
{
    interface IFornecedorService
    {
        Task AdicionarAsync(Fornecedor fornecedor);
        Task AtualizarAsync(Fornecedor fornecedor);
        Task RemoverAsync(Guid id);
        Task AtualizarEnderecoAsync(Endereco endereco);
    }
}
