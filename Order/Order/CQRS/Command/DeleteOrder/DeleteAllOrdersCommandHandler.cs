using MediatR;
using Order.CQRS.Command.AddOrder;
using Order.Repository;

namespace Order.CQRS.Command.DeleteOrder
{
    public class DeleteAllOrdersCommandHandler : IRequestHandler<DeleteAllOrdersCommand, DeleteAllOrdersCommandResponse>
    {
        private readonly IOrderRepository orderRepository;

        public DeleteAllOrdersCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<DeleteAllOrdersCommandResponse> Handle(DeleteAllOrdersCommand request, CancellationToken cancellationToken)
        {
            return new DeleteAllOrdersCommandResponse() { Success = await orderRepository.DeleteAll() };
        }
    }
}
