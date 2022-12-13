
using Infrastructure.EF.Context;
using MediatR;
using ShareKernel.Core;

namespace Infrastructure.Compras.EF
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _context;
        private readonly IMediator _mediator;

        public UnitOfWork(WriteDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task Commit()
        {
            //Obtener los eventos de dominio
            var domainEvents = _context.ChangeTracker.Entries<Entity>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)                
                .Where(x => !x.Consumed)
                .ToArray();

            //Publicar los eventos de dominio
            foreach(var evento in domainEvents)
            {
                evento.MarkAsConsumed();
                await _mediator.Publish(evento);
                
            }

            //Confirmar todo
            await _context.SaveChangesAsync();
        }
    }
}
