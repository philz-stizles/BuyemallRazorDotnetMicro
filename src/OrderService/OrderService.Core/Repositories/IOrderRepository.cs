using OrderService.Core.Entities;
using OrderService.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Core.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string username);
    }
}
