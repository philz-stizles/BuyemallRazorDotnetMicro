using AutoMapper;
using OrderService.Application.Commands;
using OrderService.Application.Responses;
using OrderService.Core.Entities;

namespace OrderService.Application.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        }
    }
}
