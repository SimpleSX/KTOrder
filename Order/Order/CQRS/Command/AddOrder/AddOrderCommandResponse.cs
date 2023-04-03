using Order.Common;

namespace Order.CQRS.Command.AddOrder
{
    public class AddOrderCommandResponse : Response
    {
        public OrderModel Order { get; set; }
    }
}
