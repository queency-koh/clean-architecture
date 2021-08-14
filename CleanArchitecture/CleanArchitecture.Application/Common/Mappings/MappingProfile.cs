using AutoMapper;
using CleanArchitecture.Application.TodoLists.Queries.GetTodoLists;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoList, TodoListDto>();

            CreateMap<TodoItem, TodoItemDto>()
                .ForMember(d => d.PriorityLevel, opt =>
                    opt.MapFrom(s => (int)s.PriorityLevel));
        }
    }
}
