using AutoMapper;
using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EletronicSystem.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioService(IMapper mapper, UserManager<Usuario> usuario)
        {
            _mapper = mapper;
            _userManager = usuario;
        }

        public async Task<IList<UsuarioViewModel>> ObterTodos()
        {
            var obter = _userManager.Users.ToList();

            return _mapper.Map<IList<UsuarioViewModel>>(obter); ;
        }

        public async Task<UsuarioViewModel> ObterPorId(Guid id)
        {
            var obter = await _userManager.FindByIdAsync(id.ToString());

            if (obter == null)
            {
                Console.WriteLine("Usuario nao encontrado");
            }

            return _mapper.Map<UsuarioViewModel>(obter); ;
        }

        public async Task<IdentityResult> Criar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            usuario.Email = usuario.UserName;
            usuario.EmailConfirmed = true;

            try
            {
                var resultado = await _userManager.CreateAsync(usuario, "Admin@123");

                if (resultado.Succeeded)
                {
                    usuarioViewModel.OperacaoValida = true;
                    return IdentityResult.Success;
                }
                else
                {
                    usuarioViewModel.OperacaoValida = false;
                    Console.WriteLine(resultado.Errors);

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar usuário: {ex.Message}");

                return IdentityResult.Failed(new IdentityError { Description = "Ocorreu um erro inesperado ao criar o usuário." });
            }
        }

        public async Task<UsuarioViewModel> Atualizar(UsuarioViewModel usuario)
        {
            try
            {
                var usuarioExistente = await _userManager.FindByIdAsync(usuario.Id.ToString());

                if (usuarioExistente == null)
                {
                    usuario.MsgErro.Add("", "Usuário não encontrado.");
                    return usuario;
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar usuário: {ex.Message}");
                usuario.MsgErro.Add("", "Erro interno ao atualizar o usuário.");
            }

            return usuario;
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
