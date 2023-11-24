using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Exceptions;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService, ILogger<UpdateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)//unit no returning obj means
        {
            //update order
           var ordertoupdate= await _orderRepository.GetByIdAsync(request.Id);
            if (ordertoupdate == null)
            {
                throw new NotFoundExceptions(nameof(Order), request.Id);
            }
            _mapper.Map(request, ordertoupdate, typeof(UpdateOrderCommand), typeof(Order));
            await _orderRepository.UpdateAsync(ordertoupdate);

            _logger.LogInformation($"Order {ordertoupdate.Id} is successfully updated.");

            return Unit.Value;


        }
    }
}
