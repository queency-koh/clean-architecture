using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandValidator
            : AbstractValidator<CreateTodoListCommand>
    {
        private readonly IApplicationDbContext context;

        public CreateTodoListCommandValidator(
            IApplicationDbContext context)
        {
            this.context = context;

            RuleFor(v => v.Title)
                .MaximumLength(240)
                .NotEmpty()
                .MustAsync(BeUniqueTitle)
                    .WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueTitle(string title,
            CancellationToken cancellationToken)
        {
            return await context.TodoLists
                .AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}
