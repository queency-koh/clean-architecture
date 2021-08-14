using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Application.TodoLists.Queries.GetTodoLists
{
    public class TodosVm
    {
        public List<PriorityLevelDto> PriorityLevels
        {
            get
            {
                return Enum.GetValues(typeof(PriorityLevel))
                    .Cast<PriorityLevel>()
                    .Select(priorityLevel => new PriorityLevelDto
                    {
                        Value = (int)priorityLevel,
                        Name = priorityLevel.ToString()
                    })
                    .ToList();
            }
        }

        public List<TodoListDto> Lists { get; set; }
    }
}
