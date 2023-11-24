using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    //will be triggered from mediatr when the request comes.
    public class GetOrderListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVm>> //first request paramteter, second expected response parameter
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrdersVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
           var orderlist = await _orderRepository.GetOrderByUsername(request.UserName);
            return  _mapper.Map<List<OrdersVm>>(orderlist);
             
        }
    }
}
