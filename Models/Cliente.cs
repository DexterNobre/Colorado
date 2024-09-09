using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrudColorado.Models
{
    public class Cliente
    {
        [Key]
        public int CodigoCliente { get; set; }

        [Required]
        public string RazaoSocial { get; set; } = string.Empty;

        public string NomeFantasia { get; set; } = string.Empty;

        [Required]
        public string TipoPessoa { get; set; } = string.Empty;

        [Required]
        public string Documento { get; set; } = string.Empty;

        [Required]
        public string Endereco { get; set; } = string.Empty;

        public string Complemento { get; set; } = string.Empty;

        [Required]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        public string Cidade { get; set; } = string.Empty;

        [Required]
        public string CEP { get; set; } = string.Empty;

        [Required]
        public string UF { get; set; } = string.Empty;

        [Required]
        public DateTime DataInsercao { get; set; }

        [Required]
        public string UsuarioInsercao { get; set; } = string.Empty;

        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
