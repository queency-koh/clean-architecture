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
    public class GetTodoListsQuery : IRequest<TodosVm>
    {
    }

    public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, TodosVm>
    {
        private readonly IApplicationDbContext context;

        public GetTodoListsQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<TodosVm> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
            var vm = new TodosVm();

            vm.Lists = await context.TodoLists
                    .Select(TodoListDto.Projection)
                    .ToListAsync(cancellationToken);

            return vm;
        }
    }
}
