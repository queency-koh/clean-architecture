using AutoMapper;
using CleanArchitecture.Application.TodoLists.Queries.GetTodoLists;
using CleanArchitecture.Domain.Entities;
using System;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Common.Mappings
{
    public class MappingTests : IClassFixture<MappingFixture>
    {
        private readonly IMapper mapper;

        public MappingTests(MappingFixture fixture)
        {
            mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            mapper
                .ConfigurationProvider
                .AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(TodoList), typeof(TodoListDto))]
        [InlineData(typeof(TodoItem), typeof(TodoItemDto))]
        public void ShouldSupportMappingFromSourceToDestination
            (Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            mapper.Map(instance, source, destination);
        }
    }
}
