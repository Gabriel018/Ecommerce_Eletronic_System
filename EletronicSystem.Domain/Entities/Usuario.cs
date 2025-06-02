using Microsoft.AspNetCore.Identity;

namespace EletronicSystem.Domain.Entities
{
    public class Usuario: IdentityUser
    {
        public required string Nome { get; set; }    
        public required string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public required string Endereco { get; set; }
    }
}
