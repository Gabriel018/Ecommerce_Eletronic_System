
namespace EletronicSystem.Domain.Entities
{
    public class Produto : Entity
    {
        public string? Foto { get; set; }
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }
        public string? Categoria { get; set; }
        public Guid? ClienteId {get; set;}
        public Cliente? Cliente { get; set; }
    }
}
