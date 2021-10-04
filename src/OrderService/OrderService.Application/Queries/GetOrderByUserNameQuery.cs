using MediatR;
using OrderService.Application.Responses;
using System;
using System.Collections.Generic;

namespace OrderService.Application.Queries
{
    public class GetOrderByUserNameQuery: IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }

        public GetOrderByUserNameQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
