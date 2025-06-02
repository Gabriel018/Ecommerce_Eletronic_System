using AutoMapper;
using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EletronicSystem.Business.Services
{
    public class UsuarioService(IMapper mapper, UserManager<Usuario> usuario) : IUsuarioService
    {
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<Usuario> _userManager = usuario;

        public async Task<IList<UsuarioViewModel>> ObterTodos()
        {
            var obter = await _userManager.Users.ToListAsync();

            return _mapper.Map<IList<UsuarioViewModel>>(obter);
        }

        public async Task<UsuarioViewModel> ObterPorId(Guid id)
        {
            var obter = await _userManager.FindByIdAsync(id.ToString());

            if (obter == null)
            {
                Console.WriteLine("Usuario nao encontrado");
            }

            return _mapper.Map<UsuarioViewModel>(obter);
        }

        public async Task<IdentityResult> Criar(UsuarioViewModel usuario)
        {
            usuario.Email = usuario.UserName;
            usuario.EmailConfirmed = true;

            var usuarioEntity = _mapper.Map<Usuario>(usuario);


            var resultado = await _userManager.CreateAsync(usuarioEntity, "Admin@123");

            if (resultado.Succeeded)
            {
                usuario.OperacaoValida = true;
                return IdentityResult.Success;
            }
            else
            {
                usuario.OperacaoValida = false;
                Console.WriteLine(resultado.Errors);

                return resultado;
            }
        }

        public async Task<IdentityResult> Atualizar(UsuarioViewModel usuario)
        {
            var usuarioExistente = await _userManager.FindByIdAsync(usuario.Id.ToString());

            if (usuarioExistente == null)
            {
                usuario.MsgErro.Add("", "Usuário não encontrado.");
                return IdentityResult.Success;
            }

            _mapper.Map(usuario, usuarioExistente);

            var resultado = await _userManager.UpdateAsync(usuarioExistente);

            if (!resultado.Succeeded)
            {
                foreach (var error in resultado.Errors)
                {
                    usuario.MsgErro.Add("", error.Description);
                }
            }
            return resultado;
        }

        public async Task<UsuarioViewModel> Deletar(Guid id)
        {
            var response = new UsuarioViewModel();

            var usuarioExistente = await _userManager.FindByIdAsync(id.ToString());

            if (usuarioExistente == null)
            {
                response.MsgErro.Add("", "Usuário não encontrado.");
                return response;
            }
            else
            {
                var retorno = await _userManager.DeleteAsync(usuarioExistente);

                if (!retorno.Succeeded)
                {
                    response.MsgErro.Add("", retorno.Errors.FirstOrDefault()?.Description ?? "");
                }

                return response;
            }
        }
    }
}
