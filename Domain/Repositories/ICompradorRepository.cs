using Domain.Model.Compradores;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICompradorRepository : IRepository<Comprador, Guid>
    {
        Task UpdateAsync(Comprador obj);
        Task RemoveAsync(Comprador obj);
    }
}
