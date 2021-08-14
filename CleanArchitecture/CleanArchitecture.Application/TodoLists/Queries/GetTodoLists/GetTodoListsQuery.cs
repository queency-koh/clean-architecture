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
    public class GetTodoListsQuery : IRequest<List<TodoListDto>>
    {
    }

    public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, List<TodoListDto>>
    {
        private readonly IApplicationDbContext context;

        public GetTodoListsQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TodoListDto>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
            return await context.TodoLists
                    .Select(TodoListDto.Projection)
                    .ToListAsync(cancellationToken);
        }
    }
}
