using System.ComponentModel.DataAnnotations.Schema;

namespace EletronicSystem.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        [NotMapped]
        public string Msg { get; set; }
        [NotMapped]
        public string OperacaoValida {  get; set; }
    }
}
