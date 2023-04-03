using Order.Common;

namespace Order.CQRS.Query.GetOrderById
{
    public class GetOrderByIdQueryResponse : Response
    {
        public OrderModel Order { get; set; }
    }
}
