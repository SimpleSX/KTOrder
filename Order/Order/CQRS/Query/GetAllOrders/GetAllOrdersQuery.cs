using MediatR;

namespace Order.CQRS.Query.GetAllOrders
{
    public record GetAllOrdersQuery()
        : IRequest<GetAllOrdersQueryResponse>;
}
