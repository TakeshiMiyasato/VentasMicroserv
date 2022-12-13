using Domain.Model.Compradores;
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
    internal class CompradorRepository : ICompradorRepository
    {
        private readonly WriteDbContext _context;

        public CompradorRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Comprador obj)
        {
            await _context.Compradores.AddAsync(obj);
        }

        public async Task<Comprador?> FindByIdAsync(Guid id)
        {
            return await _context.Compradores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Comprador obj)
        {
            _context.Compradores.Remove(obj);
            return Task.CompletedTask;

        }

        public Task UpdateAsync(Comprador obj)
        {
            _context.Compradores.Update(obj);
            return Task.CompletedTask;
        }
    }
}
