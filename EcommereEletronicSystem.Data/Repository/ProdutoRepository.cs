using EletronicSystem.Data.Data.Contexts;
using EletronicSystem.Data.Repository.Interfaces;
using EletronicSystem.Domain.Entities;
using EletronicSystem.Domain.Repository;

namespace EletronicSystem.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
