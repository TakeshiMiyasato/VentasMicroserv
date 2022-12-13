using Domain.Model.Compradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.ReadModel
{
    internal class CompradorReadModel
    {
        [Key]
        [Column("compradorId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column("nombreCompleto")]
        [MaxLength(250)]
        public string NombreCompleto { get; set; }

        [Required]
        [Column("ubicacion")]
        [MaxLength(250)]
        public string Ubicacion { get; set; }

        [Required]
        [Column("nombreTienda")]
        [MaxLength(250)]
        public string NombreTienda { get; set; }

        [Required]
        [Column("tipoTienda")]
        [MaxLength(250)]
        public string TipoTienda { get; set; }

        [Required]
        [Column("telefono")]
        [MaxLength(250)]
        public string Telefono { get; set; }

        public CompradorReadModel()
        {
            NombreCompleto = "";
            Ubicacion = "";
            NombreTienda = "";
            TipoTienda = "";
            Telefono = "";
        }

        public static implicit operator CompradorReadModel?(Comprador? v)
        {
            throw new NotImplementedException();
        }
    }
}
