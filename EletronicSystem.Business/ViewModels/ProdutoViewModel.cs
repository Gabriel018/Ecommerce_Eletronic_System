namespace EletronicSystem.Business.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }
        public Guid? ClienteId { get; set; }
    }
}
