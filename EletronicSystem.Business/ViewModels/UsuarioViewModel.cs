

namespace EletronicSystem.Business.ViewModels
{
    public class UsuarioViewModel: BaseViewModel
    {
        public string? UserName { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Endereco { get; set; }
    }
}
