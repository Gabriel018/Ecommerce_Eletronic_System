﻿
namespace EletronicSystem.Domain.Entities
{
    public class Produto : Entity
    {
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }
        public Guid? ClienteId {get; set;}
        public Cliente? Cliente { get; set; }
    }
}