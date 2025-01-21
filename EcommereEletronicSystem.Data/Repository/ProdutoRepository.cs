using EletronicSystem.Data.Data.Contexts;
using EletronicSystem.Data.Repository.Interfaces;
using EletronicSystem.Domain.Entities;
using EletronicSystem.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace EletronicSystem.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly ApplicationDbContext _context;
        public ProdutoRepository(ApplicationDbContext db , ApplicationDbContext context) : base(db)
        {
            _context = context;
        }

        public async Task <List<Produto>> FiltrarPorcategoria(string categoria)
        {
            var produtos = await _context.Produtos.Where(p => p.Categoria == categoria).ToListAsync();

            return produtos;
        }
    }
}
