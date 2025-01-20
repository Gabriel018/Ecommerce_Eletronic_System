using EletronicSystem.Domain.Entities;

namespace EletronicSystem.Domain.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>>ObterTodos();
        Task<TEntity> ObterPorId(Guid id);
        Task<bool> Adicionar(TEntity entity);
        Task<bool> Atualizar (TEntity entity);
        Task<bool>  Deletar(Guid id);
    }
}
