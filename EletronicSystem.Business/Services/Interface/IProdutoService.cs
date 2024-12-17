

using EletronicSystem.Business.ViewModels;

namespace EletronicSystem.Business.Services.Interface
{
    public interface IProdutoService
    {
        Task<IEnumerable<ClienteViewModel>> ObterTodos();
        Task<ClienteViewModel> ObterPorId(Guid id);
        Task<ClienteViewModel> Adicionar(ClienteViewModel obj);
        Task<ClienteViewModel> Atualizar(ClienteViewModel obj);
        Task<ClienteViewModel> Deletar(Guid id);
    }
}
