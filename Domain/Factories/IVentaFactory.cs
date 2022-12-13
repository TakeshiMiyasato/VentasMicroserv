using Domain.Model.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories
{
    public interface IVentaFactory
    {
        Venta CrearVenta(Guid? compradorId);
        Venta CrearVenta();
    }
}
