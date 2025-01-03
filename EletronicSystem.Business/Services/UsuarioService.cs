﻿using AutoMapper;
using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

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
            var retorno = _mapper.Map<IList<UsuarioViewModel>>(obter);

            return retorno;
        }

        public Task<UsuarioViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
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
