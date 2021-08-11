using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoLists.Queries.GetTodoLists
{
    public interface IGetTodoListsQuery
    {
        Task<List<TodoList>> Handle();
    }

    public class GetTodoListsQuery : IGetTodoListsQuery
    {
        private readonly IApplicationDbContext context;

        public GetTodoListsQuery(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TodoList>> Handle()
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
                    }).ToListAsync();
        }
    }
}
