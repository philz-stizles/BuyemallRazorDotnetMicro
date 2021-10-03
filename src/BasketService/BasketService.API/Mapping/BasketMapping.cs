using AutoMapper;
using BasketService.API.Entities;
using EventBusRabbitMQ.Events;

namespace BasketService.API.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
