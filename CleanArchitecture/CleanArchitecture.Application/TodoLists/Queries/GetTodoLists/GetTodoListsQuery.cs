using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
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
        private readonly IMapper mapper;

        public GetTodoListsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TodosVm> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
            return new TodosVm
            {
                Lists = await context.TodoLists
                     .ProjectTo<TodoListDto>(mapper.ConfigurationProvider)
                     .ToListAsync(cancellationToken)
            };
        }
    }
}
