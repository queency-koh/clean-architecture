using CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandTests : TestFixture
    {
        [Fact]
        public async Task Handle_ShouldPersistTodoList()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Bucket List"
            };

            var handler = new CreateTodoListCommandHandler(Context);

            var result = await handler.Handle(command,
                CancellationToken.None);

            var entity = Context.TodoLists.Find(result);

            entity.Should().NotBeNull();
            entity.Title.Should().Be(command.Title);
        }
    }
}
