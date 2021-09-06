using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Application.TodoLists.Queries.GetTodoLists
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IList<TodoItemDto> Items { get; set; }
    }
}
