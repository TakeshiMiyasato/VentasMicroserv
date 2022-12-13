using Domain.Model.Ventas;
using Domain.Repositories;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repository
{
    internal class VentaRepository : IVentaRepository
    {
        private readonly WriteDbContext _context;

        public VentaRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Venta obj)
        {
            await _context.Ventas.AddAsync(obj);
        }
        public Task UpdateAsync(Venta obj)
        {
            _context.Ventas.Update(obj);
            return Task.CompletedTask;
        }

        public async Task<Venta?> FindByIdAsync(Guid id)
        {
            return await _context.Ventas
                .Include("_detalle")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
