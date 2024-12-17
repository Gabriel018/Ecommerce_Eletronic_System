using EletronicSystem.Data.Data.Contexts;
using EletronicSystem.Data.Repository.Interfaces;
using EletronicSystem.Domain.Entities;
using EletronicSystem.Domain.Repository;

namespace EletronicSystem.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
