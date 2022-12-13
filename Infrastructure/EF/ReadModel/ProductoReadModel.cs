using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.ReadModel
{
    internal class ProductoReadModel
    {
        [Key]
        [Column("productoId")]
        public Guid Id { get; set; }

        [Required]
        [Column("nombreProducto")]
        [MaxLength(250)]
        public string NombreProducto { get; set; }

        [Required]
        [Column("stock")]
        [MaxLength(250)]
        public int Stock { get; set; }

        [Required]
        [Column("precio")]
        [MaxLength(250)]
        public decimal Precio { get; set; }
    }
}
