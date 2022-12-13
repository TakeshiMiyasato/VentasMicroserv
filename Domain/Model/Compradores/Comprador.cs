using SharedKernel.ValueObjects;
using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Compradores
{
    public class Comprador : AggregateRoot
    {
        public PersonNameValue NombreCompleto { get; private set; }
        public UbicacionValue Ubicacion { get; private set; }
        public PersonNameValue NombreTienda { get; private set; }
        public PersonNameValue TipoTienda { get; private set; }
        public TelefonoValue Telefono { get; private set; }

        public Comprador(string nombreComprador, string ubicacionComprador, string nombreTienda, string tipoTienda, string telefono)
        {
            Id = Guid.NewGuid();
            NombreCompleto = nombreComprador;
            Ubicacion = ubicacionComprador;
            NombreTienda = nombreTienda;
            TipoTienda = tipoTienda;
            Telefono = telefono;
        }

        public void EditComprador(string nombreComprador, string ubicacionComprador, string nombreTienda, string tipoTienda, string telefono)
        {
            NombreCompleto = nombreComprador;
            Ubicacion = ubicacionComprador;
            NombreTienda = nombreTienda;
            TipoTienda= tipoTienda;
            Telefono = telefono;
        }

        private Comprador() { }
    }
}
