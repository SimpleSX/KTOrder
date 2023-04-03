using MediatR;
using Order.CQRS.Command.AddOrder;

namespace Order.CQRS.Command.UpdateOrder
{
    public record UpdateOrderCommand (Guid Id, string Maker, string Model, int Year)
        : IRequest<UpdateOrderCommandResponse>;
}
