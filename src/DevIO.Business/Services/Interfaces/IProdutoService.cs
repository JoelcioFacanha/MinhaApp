using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services.Interfaces
{
    interface IProdutoService
    {
        Task AdicionarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task RemoverAsync(Guid id);
    }
}
