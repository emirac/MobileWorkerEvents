using FluentValidation;

namespace MobileWorkerEvents.Application.Events.Commands.CreateEventCommand
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(e => e.Date)
                .NotNull();

            RuleFor(e => e.Quantity)
                .NotNull()
                .GreaterThan(0);

            RuleFor(e => e.Price)
                .GreaterThan(0)
                .When(e => e.IsExpense)
                .WithMessage("If event is expense, price is required");

            RuleFor(e => e.Name)
                .NotNull();

            RuleFor(e => e.IsExpense)
                .NotNull();
        }
    }
}
