using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoLists.Queries.GetTodoLists
{
    public class GetTodoListsQuery : IRequest<List<TodoList>>
    {
    }

    public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, List<TodoList>>
    {
        private readonly IApplicationDbContext context;

        public GetTodoListsQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TodoList>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
            return await context.TodoLists
                    .Select(todo => new TodoList
                    {
                        Id = todo.Id,
                        Title = todo.Title,
                        Items = todo.Items.Select(item => new TodoItem
                        {
                            Id = item.Id,
                            ListId = item.ListId,
                            Title = item.Title,
                            Done = item.Done,
                            PriorityLevel = item.PriorityLevel,
                            Note = item.Note
                        }).ToList()
                    }).ToListAsync(cancellationToken);
        }
    }
}
