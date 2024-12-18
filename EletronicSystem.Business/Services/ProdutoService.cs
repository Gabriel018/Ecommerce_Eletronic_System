

using AutoMapper;
using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Data.Data.Contexts;
using EletronicSystem.Data.Repository.Interfaces;

namespace EletronicSystem.Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(ApplicationDbContext context,IMapper mapper,IProdutoRepository produtoRepository)
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

        public Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> Adicionar(ProdutoViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> Atualizar(ProdutoViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
