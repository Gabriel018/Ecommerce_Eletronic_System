using EletronicSystem.Domain.Entities;
using EletronicSystem.Domain.Repository.Interfaces;

namespace EletronicSystem.Data.Repository.Interfaces
{
    public interface IProdutoRepository: IBaseRepository<Produto>
    {
        Task<List<Produto>> FiltrarPorcategoria(string categoria);
    }
}
