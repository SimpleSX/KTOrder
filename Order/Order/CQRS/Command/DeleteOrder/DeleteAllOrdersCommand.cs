using MediatR;

namespace Order.CQRS.Command.DeleteOrder
{
    public record DeleteAllOrdersCommand()
        : IRequest<DeleteAllOrdersCommandResponse>;
}
