using EletronicSystem.Data.Data.Contexts;
using EletronicSystem.Domain.Entities;
using EletronicSystem.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EletronicSystem.Domain.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ApplicationDbContext _Db;
        protected readonly DbSet<TEntity> _DbSet;
        protected BaseRepository(ApplicationDbContext db)
        {
            _Db = db;
            _DbSet = db.Set<TEntity>();

        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            try
            {
                var obj = await _DbSet.ToListAsync();
                return obj;
            }

            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<TEntity> ObterPorId(int id)
        {
            return await _DbSet.FindAsync();
        }

        public async Task<bool> Adicionar(TEntity entity)
        {
            try
            {
                await _DbSet.AddAsync(entity);
                await SalvaAlteracoes();
                return true;
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task Atualizar(TEntity entity)
        {
            try
            {
                _DbSet.Update(entity);
                await SalvaAlteracoes();
            }

            catch (Exception ex)
            {
              Console.WriteLine($"{ex.ToString()}");
            }
        }

        public async Task Deletar(Guid id)
        {
            _DbSet.Remove(new TEntity { Id = id });
            await SalvaAlteracoes();
        }

        public async Task SalvaAlteracoes()
        {
            await _Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _Db?.DisposeAsync();
        }
    }
}
