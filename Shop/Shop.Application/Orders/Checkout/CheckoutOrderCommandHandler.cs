﻿using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.Checkout;

public class CheckoutOrderCommandHandler : IBaseCommandHandler<CheckoutOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public CheckoutOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var currentOrder = await _orderRepository.GetCurrentUserOrder(request.UserId);
        if (currentOrder == null)
        {
            return OperationResult.NotFound();
        }

        var address = new OrderAddress(request.FirstName, request.LastName, request.Shire, request.City, request.PostalCode, request.PostalAddress, request.PhoneNumber, request.NationalCode);
        currentOrder.Checkout(address);
        await _orderRepository.Save();
        return OperationResult.Success();

    }
}