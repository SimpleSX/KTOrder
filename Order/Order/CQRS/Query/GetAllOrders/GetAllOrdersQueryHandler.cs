using MediatR;
using Order.Repository;

namespace Order.CQRS.Query.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, GetAllOrdersQueryResponse>
    {
        private readonly IOrderRepository orderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetAll();
            return new GetAllOrdersQueryResponse() { Orders = orders, Success = true };
        }
    }
}
