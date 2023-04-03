using MediatR;
using Order.Common;
using Order.Repository;

namespace Order.CQRS.Command.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, AddOrderCommandResponse>
    {
        private readonly IOrderRepository orderRepository;

        public AddOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<AddOrderCommandResponse> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new OrderModel
            {
                Id = Guid.NewGuid(),
                Make = (CarMake)Enum.Parse(typeof(CarMake), request.Maker.ToLowerInvariant()),
                Model = request.Model,
                Year = request.Year
            };

            if(await orderRepository.Add(order))
                return new AddOrderCommandResponse() { Order = order, Success = true };

            return new AddOrderCommandResponse() { Success = false };
        }
    }
}
