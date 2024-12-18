namespace EletronicSystem.Business.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }
        public string? Categoria { get; set; }
        public Guid? ClienteId { get; set; }
    }
}
