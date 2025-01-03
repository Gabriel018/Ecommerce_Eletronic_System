using EletronicSystem.Business.ViewModels;
using EletronicSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace EletronicSystem.Business.Services.Interface
{
    public interface IUsuarioService
    {
        Task<IList<UsuarioViewModel>> ObterTodos();
        Task<UsuarioViewModel> ObterPorId(Guid id);
        Task<IdentityResult> Criar(UsuarioViewModel usuario);
        Task<UsuarioViewModel> Atualizar(UsuarioViewModel usuario);
        Task<UsuarioViewModel> Deletar(UsuarioViewModel usuario);   
    }
}
