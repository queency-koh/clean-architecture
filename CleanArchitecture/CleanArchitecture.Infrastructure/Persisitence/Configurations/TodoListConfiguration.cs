using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persisitence.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public static void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.Property(t => t.Title)
               .HasMaxLength(280)
               .IsRequired();
        }
    }
}
