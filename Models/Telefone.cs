using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrudColorado.Models
{
    public class Telefone
    {
        [Key]
        [Column(Order = 1)]
        public int CodigoCliente { get; set; }

        [Key]
        [Column(Order = 2)]
        public string NumeroTelefone { get; set; } = string.Empty;

        [Required]
        public int CodigoTipoTelefone { get; set; }

        [Required]
        public string Operador { get; set; } = string.Empty;

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public DateTime DataInsercao { get; set; }

        [Required]
        public string UsuarioInsercao { get; set; } = string.Empty;

        [ForeignKey(nameof(CodigoCliente))]
        public Cliente Cliente { get; set; } = new Cliente();

        [ForeignKey(nameof(CodigoTipoTelefone))]
        public TipoTelefone TipoTelefone { get; set; } = new TipoTelefone();
    }
}
