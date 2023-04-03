using FluentValidation;
using MediatR;
using Order.Common;

namespace Order.CQRS.Command.AddOrder
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            RuleFor(o => o.Year).NotEmpty();
            RuleFor(o => o.Model).NotEmpty();
            RuleFor(o => o.Maker).NotEmpty().Must(BeValidCarMaker).WithMessage("Not a valid car maker");
        }

        private bool BeValidCarMaker(string maker)
        {
            return Enum.TryParse(typeof(CarMake), maker, true, out object? output);
        }
    }
}
