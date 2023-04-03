using MediatR;
using Order.CQRS.Query.GetAllOrders;
using Order.CQRS.Query.GetOrder;
using Order.Repository;

namespace Order.CQRS.Query.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResponse>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.Get(request.Id);

            if(order == null)
                return new GetOrderByIdQueryResponse() { Success = false };
            return new GetOrderByIdQueryResponse() { Order = order, Success = true };
        }
    }
}
