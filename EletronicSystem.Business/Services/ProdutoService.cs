

using AutoMapper;
using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Data.Data.Contexts;
using EletronicSystem.Data.Repository.Interfaces;
using EletronicSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EletronicSystem.Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(ApplicationDbContext context, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _context = context;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var obter = await _produtoRepository.ObterTodos();
            var retorno = _mapper.Map<IEnumerable<ProdutoViewModel>>(obter);

            return retorno;
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            var response = new ProdutoViewModel();

            var produto = await _produtoRepository.ObterPorId(id);

            if (produto == null)
            {
                response.MsgErro.Add("", "Erro ao encontrar usario");
            }

            response = _mapper.Map<ProdutoViewModel>(produto);
            response.OperacaoValida = true;

            return response;
        }

        public async Task<ProdutoViewModel> Adicionar(ProdutoViewModel obj)
        {
            var produto = _mapper.Map<Produto>(obj);
            bool response = await _produtoRepository.Adicionar(produto);

            if (response)
                obj.OperacaoValida = true;
            else
                obj.OperacaoValida = false;


            return obj;
        }

        public async Task<ProdutoViewModel> Atualizar(ProdutoViewModel obj)
        {
            var produto = await _produtoRepository.ObterPorId(obj.Id);
            _mapper.Map(obj, produto);

            try
            {
                await _produtoRepository.Atualizar(produto);

                obj.OperacaoValida = true;
            }

            catch (Exception ex)
            {
                obj.MsgErro.Add("", "Falha ao atualizar usuario");

            }
            return obj;
        }

        public async Task<ProdutoViewModel> Deletar(Guid id)
        {
            ProdutoViewModel produto = new ProdutoViewModel();

            var response = await _produtoRepository.Deletar(id);

            if (response)
                produto.OperacaoValida = true;
            else
                produto.MsgErro.Add("", "Falhar ao excluir");

            return produto;
        }
    }
}
