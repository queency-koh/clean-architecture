using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoLists.Commands.UpdateTodoList
{
    public class UpdateTodoListCommand : IRequest
    {
        public long Id { get; set; }

        public string Title { get; set; }
    }

    public class UpdateTodoListCommandHandler
        : IRequestHandler<UpdateTodoListCommand>
    {
        private readonly IApplicationDbContext context;

        public UpdateTodoListCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateTodoListCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await context.TodoLists.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }

            entity.Title = request.Title;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
