

using EletronicSystem.Business.ViewModels;

namespace EletronicSystem.Business.Services.Interface
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);
        Task<List<ProdutoViewModel>> FiltrarPorCategoria(string categoria);
        Task<ProdutoViewModel> Adicionar(ProdutoViewModel obj);
        Task<ProdutoViewModel> Atualizar(ProdutoViewModel obj);
        Task<ProdutoViewModel> Deletar(Guid id);
    }
}
