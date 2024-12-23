using EletronicSystem.Business.ViewModels;
using EletronicSystem.Domain.Entities;

namespace EletronicSystem.Business.Services.Interface
{
    public interface IUsuarioService
    {
        Task<ICollection<UsuarioViewModel>> ObterTodos();
        Task<UsuarioViewModel> ObterPorId(Guid id);
        Task<Usuario> Criar(Usuario usuario);
        Task<UsuarioViewModel> Atualizar(UsuarioViewModel usuario);
        Task<UsuarioViewModel> Deletar(UsuarioViewModel usuario);   
    }
}
