using Microsoft.AspNetCore.Identity;

namespace EletronicSystem.Domain.Entities
{
    public class Usuario: IdentityUser
    {
        public string Nome { get; set; }    
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
    }
}
