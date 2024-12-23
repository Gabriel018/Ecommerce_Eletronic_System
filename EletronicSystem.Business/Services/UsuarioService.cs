using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Domain.Entities;

namespace EletronicSystem.Business.Services
{
    public class UsuarioService : IUsuarioService
    {

        public Task<ICollection<UsuarioViewModel>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Criar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioViewModel> Atualizar(UsuarioViewModel usuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioViewModel> Deletar(UsuarioViewModel usuario)
        {
            throw new NotImplementedException();
        }
    }
}
