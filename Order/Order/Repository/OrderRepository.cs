using Order.Common;

namespace Order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public List<OrderModel> Orders = new List<OrderModel>();

        public Task<bool> Add(OrderModel order)
        {
            this.Orders.Add(order);

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAll()
        {
            this.Orders = new List<OrderModel>();

            return Task.FromResult(true);
        }

        public Task<bool> Update(OrderModel order)
        {
            var oldOrder = this.Orders.First(o => o.Id == order.Id);

            oldOrder.Make = order.Make;
            oldOrder.Year = order.Year;
            oldOrder.Model = order.Model;

            return Task.FromResult(true);
        }

        public Task<OrderModel?> Get(Guid Id)
        {
            return Task.FromResult(this.Orders.FirstOrDefault(o => o.Id == Id));
        }

        public Task<IEnumerable<OrderModel>> GetAll()
        {
            return Task.FromResult(this.Orders.AsEnumerable());
        }
    }
}
