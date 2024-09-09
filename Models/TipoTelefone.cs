using System;
using System.ComponentModel.DataAnnotations;

namespace GrudColorado.Models
{
    public class TipoTelefone
    {
        [Key]
        public int CodigoTipoTelefone { get; set; }

        [Required]
        public string DescricaoTipoTelefone { get; set; } = string.Empty;

        [Required]
        public DateTime DataInsercao { get; set; }

        [Required]
        public string UsuarioInsercao { get; set; } = string.Empty;
    }
}
