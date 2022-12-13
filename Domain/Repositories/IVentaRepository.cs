using Domain.Model.Ventas;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IVentaRepository : IRepository<Venta, Guid>
    {
        Task UpdateAsync(Venta obj);
    }
}
