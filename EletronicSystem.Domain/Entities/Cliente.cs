namespace EletronicSystem.Domain.Entities
{
    public class Cliente: Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int? Celular { get; set; }
        public string?  Endereco { get; set; }
        public Guid? ProdutoId {  get; set; }
        public IList<Produto>? Produto { get; set; } = new List<Produto>();    
    }
}
