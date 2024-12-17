using EletronicSystem.Business.ViewModels;

namespace EletronicSystem.Business.Services.Interface
{
    interface IClienteService
    {
        Task <IEnumerable<ClienteViewModel>> ObterTodos();
        Task<ClienteViewModel> ObterPorId(Guid id);
        Task<ClienteViewModel> Adicionar(ClienteViewModel obj);
        Task<ClienteViewModel> Atualizar(ClienteViewModel obj);
        Task<ClienteViewModel> Deletar(Guid id);

    }
}
