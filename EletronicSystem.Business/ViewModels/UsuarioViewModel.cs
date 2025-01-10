

using System.ComponentModel.DataAnnotations;

namespace EletronicSystem.Business.ViewModels
{
        public class UsuarioViewModel: BaseViewModel
        {  
            public Guid Id { get; set; }

            [Required(ErrorMessage = "Campo nome obrigatorio")]
            public string Nome { get; set; }

            [Required(ErrorMessage = "Campo email obrigatorio")]
            public string? UserName { get; set; }
           
            [Required(ErrorMessage ="Campo cpf obrigatorio")]
            public string CPF { get; set; }
            [Required(ErrorMessage ="Campo Data de nascimento obrigatorio")]
            public DateTime DataNascimento { get; set; }
            [Required(ErrorMessage ="Campo Endereço")]
            public string Endereco { get; set; }
        }
}
