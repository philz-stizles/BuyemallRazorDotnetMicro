using MediatR;
using OrderService.Application.Commands;
using OrderService.Application.Mapper;
using OrderService.Application.Responses;
using OrderService.Core.Entities;
using OrderService.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Handlers
{
    public class CheckoutOrderHandler: IRequestHandler<CheckoutOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public CheckoutOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<OrderResponse> Handle(CheckoutOrderCommand command,
            CancellationToken cancellationToken)
        {
            var orderEntity = OrderMapper.Mapper.Map<Order>(command);
            if(orderEntity == null)
            {
                throw new ApplicationException("not mapped");
            }

            var newOrder = await _orderRepository.AddAsync(orderEntity);

            var orderResponse = OrderMapper.Mapper.Map<OrderResponse>(newOrder);

            return orderResponse;
        }
    }
}
