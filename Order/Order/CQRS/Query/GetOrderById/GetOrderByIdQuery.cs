using MediatR;
using Order.CQRS.Query.GetOrderById;

namespace Order.CQRS.Query.GetOrder
{
    public record GetOrderByIdQuery(Guid Id) 
        : IRequest<GetOrderByIdQueryResponse>;
}
