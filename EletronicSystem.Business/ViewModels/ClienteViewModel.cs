namespace EletronicSystem.Business.ViewModels
{
    public  class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int? Celular { get; set; }
        public string? Endereco { get; set; }
        public Guid? ProdutoId { get; set; }
    }
}
