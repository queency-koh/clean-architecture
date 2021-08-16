using Xunit;

namespace CleanArchitecture.Application.UnitTests
{
    [CollectionDefinition(nameof(QueryCollection))]
    public class QueryCollection
        : ICollectionFixture<TestFixture>
    { }
}
