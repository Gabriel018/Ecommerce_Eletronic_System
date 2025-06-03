using AutoMapper;
using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Data.Repository.Interfaces;
using EletronicSystem.Domain.Entities;

namespace EletronicSystem.Business.Services
{
    public class ProdutoService(IMapper mapper, IProdutoRepository produtoRepository) : IProdutoService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IProdutoRepository _produtoRepository = produtoRepository;

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

        public async Task<List<ProdutoViewModel>> FiltrarPorCategoria(string categoria)
        {
            var response = new List<ProdutoViewModel>();

            var produtos = await _produtoRepository.FiltrarPorcategoria(categoria);

            if (produtos == null)
                response.FirstOrDefault()?.MsgErro.Add("", "Nenhum produto econtrado");

            response = _mapper.Map<List<ProdutoViewModel>>(produtos);

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
