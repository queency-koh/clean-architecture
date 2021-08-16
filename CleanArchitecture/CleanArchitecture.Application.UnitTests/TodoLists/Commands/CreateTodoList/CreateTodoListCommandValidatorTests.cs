using CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using CleanArchitecture.Infrastructure.Persistence;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandValidatorTests : TestFixture
    {
        private readonly ApplicationDbContext context;

        public CreateTodoListCommandValidatorTests()
        {
            context = Context;
        }

        [Fact]
        public void IsValid_ShouldBeTrue_WhenListTitleIsUnique()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Bucket List"
            };

            var validator = new CreateTodoListCommandValidator(context);

            var result = validator.Validate(command);

            result.IsValid.Should().Be(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenListTitleIsNotUnique()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Todo List"
            };

            var validator = new CreateTodoListCommandValidator(context);

            var result = validator.Validate(command);

            result.IsValid.Should().Be(false);
        }
    }
}
