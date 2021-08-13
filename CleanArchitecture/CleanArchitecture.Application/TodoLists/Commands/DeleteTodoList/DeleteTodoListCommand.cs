using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoLists.Commands.UpdateTodoList.DeleteTodoList
{
    public class DeleteTodoListCommand : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteTodoListCommandHandler
        : IRequestHandler<DeleteTodoListCommand>
    {
        private readonly IApplicationDbContext context;

        public DeleteTodoListCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteTodoListCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await context.TodoLists
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }

            context.TodoLists.Remove(entity);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
