using MediatR;
using Order.Common;
using Order.Repository;

namespace Order.CQRS.Command.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResponse>
    {
        private readonly IOrderRepository orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = new OrderModel()
            {
                Id = request.Id,
                Make = (CarMake)Enum.Parse(typeof(CarMake), request.Maker.ToLowerInvariant()),
                Model = request.Model,
                Year = request.Year
            };

            if(await orderRepository.Update(newOrder))
                return new UpdateOrderCommandResponse() { Order = newOrder, Success = true };
            
            return new UpdateOrderCommandResponse() { Success = false };
        }
    }
}
