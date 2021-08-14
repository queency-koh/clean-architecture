using AutoMapper;
using CleanArchitecture.Application.TodoLists.Queries.GetTodoLists;

namespace CleanArchitecture.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            new TodoListDto().Mapping(this);
            new TodoItemDto().Mapping(this);
        }
    }
}
