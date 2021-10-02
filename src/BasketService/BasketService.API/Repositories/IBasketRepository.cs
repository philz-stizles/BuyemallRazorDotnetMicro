using BasketService.API.Entities;
using System.Threading.Tasks;

namespace BasketService.API.Repositories
{
    public interface IBasketRepository
    {
        Task<BasketCart> GetBasket(string userName);

        Task<BasketCart> UpdateBasket(BasketCart basketCart);

        Task<bool> DeleteBasket(string userName);
    }
}
