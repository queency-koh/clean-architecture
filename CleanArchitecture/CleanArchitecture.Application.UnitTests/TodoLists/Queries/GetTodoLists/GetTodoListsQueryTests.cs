using AutoMapper;
using CleanArchitecture.Application.TodoLists.Queries.GetTodoLists;
using CleanArchitecture.Infrastructure.Persistence;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.TodoLists.Queries.GetTodoLists
{
    [Collection(nameof(QueryCollection))]
    public class GetTodoListsQueryTests : IClassFixture<TestFixture>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GetTodoListsQueryTests(TestFixture testFixture)
        {
            context = testFixture.Context;
            mapper = testFixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            // Arrange
            var query = new GetTodoListsQuery();
            var handler = new GetTodoListsQueryHandler(context, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeOfType<TodosVm>();
            result.Lists.Should().HaveCount(1);
            result.Lists[0].Items.Should().HaveCount(4);
        }
    }
}