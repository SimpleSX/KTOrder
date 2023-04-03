using Order.Common;

namespace Order.CQRS.Command.UpdateOrder
{
    public class UpdateOrderCommandResponse : Response
    {
        public OrderModel Order { get; set; }
    }
}
