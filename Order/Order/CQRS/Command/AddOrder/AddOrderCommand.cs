using MediatR;
using Order.Common;

namespace Order.CQRS.Command.AddOrder
{
    public record AddOrderCommand(string Maker, string Model, int Year) 
        : IRequest<AddOrderCommandResponse>;
}
