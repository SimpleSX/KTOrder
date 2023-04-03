using Order.Common;

namespace Order.Repository
{
    public interface IOrderRepository
    {
        Task<bool> Add(OrderModel order);
        Task<bool> DeleteAll();
        Task<bool> Update(OrderModel order);
        Task<IEnumerable<OrderModel>> GetAll();
        Task<OrderModel?> Get(Guid Id);

    }
}
