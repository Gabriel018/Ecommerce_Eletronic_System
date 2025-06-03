using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EletronicSystem.Business.ViewModels
{
    public class ProdutoViewModel : BaseViewModel
    {
        public Guid Id { get; set; }

        public IFormFile? Arquivo { get; set; }

        public byte[]? Foto { get; set; }

        [Required(ErrorMessage ="Campo descrição é obrigatorio")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Campo Valor é obrigatorio")]
        [Range(0.01, 9999.99, ErrorMessage = "O valor deve estar entre 0,01 e 9999,99.")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Campo Categoria é obrigatorio")]
        public string? Categoria { get; set; }

        public Guid? ClienteId { get; set; }
    }
}
