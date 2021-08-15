using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<long>
    {
        public int ListId { get; set; }

        public string Title { get; set; }
    }

    public class CreateTodoItemCommandHandler
            : IRequestHandler<CreateTodoItemCommand, long>
    {
        private readonly IApplicationDbContext context;

        public CreateTodoItemCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<long> Handle(CreateTodoItemCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                ListId = request.ListId,
                Title = request.Title,
                Done = false
            };

            context.TodoItems.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
