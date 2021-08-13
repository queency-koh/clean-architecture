using CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using CleanArchitecture.Application.TodoLists.Commands.UpdateTodoList;
using CleanArchitecture.Application.TodoLists.Commands.UpdateTodoList.DeleteTodoList;
using CleanArchitecture.Application.TodoLists.Queries.GetTodoLists;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoItemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoLists()
        {
            return await mediator.Send(new GetTodoListsQuery());
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, UpdateTodoListCommand command)
        {
            if (id != command.Id) return BadRequest();

            await mediator.Send(command);

            return NoContent();
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<int>> PostTodoItem(CreateTodoListCommand command)
        {
            return await mediator.Send(command);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            await mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        }
    }
}
