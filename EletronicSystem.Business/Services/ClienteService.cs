

using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;

namespace EletronicSystem.Business.Services
{
    public class ClienteService : IClienteService
    {
        public Task<ClienteViewModel> Adicionar(ClienteViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteViewModel> Atualizar(ClienteViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteViewModel> Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteViewModel>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
