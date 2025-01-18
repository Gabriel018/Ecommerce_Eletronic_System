using EletronicSystem.Domain.Entities;

namespace EletronicSystem.Domain.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>>ObterTodos();
        Task<TEntity> ObterPorId(int id);
        Task<bool> Adicionar(TEntity entity);
        Task Atualizar (TEntity entity);
        Task Deletar(Guid id);
    }
}
