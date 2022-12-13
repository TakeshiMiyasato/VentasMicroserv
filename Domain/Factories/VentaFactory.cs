using Domain.Model.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories
{
    public class VentaFactory : IVentaFactory
    {
        public Venta CrearVenta(Guid? compradorId)
        {
            if(compradorId == null || compradorId.Value == Guid.Empty)
            {
                return new Venta();
            }
            return new Venta(compradorId.Value);
        }

        public Venta CrearVenta()
        {
            return new Venta();
        }
    }
}
