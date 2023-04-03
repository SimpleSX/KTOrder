using Order.Common;
using System.Collections;

namespace Order.CQRS.Query.GetAllOrders
{
    public class GetAllOrdersQueryResponse : Response
    {
        public IEnumerable<OrderModel> Orders { get; set; }
    }
}
