using FluentValidation;
using Order.Common;
using Order.Repository;

namespace Order.CQRS.Command.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        private IOrderRepository orderRepository;

        public UpdateOrderCommandValidator(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;

            RuleFor(o => o.Id).NotEmpty().Must(Exist).WithMessage("Does not exist!");
            RuleFor(o => o.Year).NotEmpty();
            RuleFor(o => o.Model).NotEmpty();
            RuleFor(o => o.Maker).NotEmpty().Must(BeValidCarMaker).WithMessage("Not a valid car maker");
            
        }

        private bool BeValidCarMaker(string maker)
        {
            return Enum.TryParse(typeof(CarMake), maker, true, out object? output);
        }

        private bool Exist(Guid id)
        {
            return (orderRepository.Get(id)).Result != null;
        }
    }
}
