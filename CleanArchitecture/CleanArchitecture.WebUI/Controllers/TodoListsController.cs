using CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using CleanArchitecture.Application.TodoLists.Commands.UpdateTodoList;
using CleanArchitecture.Application.TodoLists.Commands.UpdateTodoList.DeleteTodoList;
using CleanArchitecture.Application.TodoLists.Queries.GetTodoLists;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoListsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/TodoLists
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<TodosVm>> GetTodoLists()
        {
            return await mediator.Send(new GetTodoListsQuery());
        }

        // POST: api/TodoLists
        [HttpPost]
        public async Task<ActionResult<int>> PostTodoList(
            CreateTodoListCommand command)
        {
            return await mediator.Send(command);
        }

        // PUT: api/TodoLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(int id,
            UpdateTodoListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/TodoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            await mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        }
    }
}
