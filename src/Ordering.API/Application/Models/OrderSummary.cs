﻿using eShop.Ordering.API.Data;

namespace eShop.Ordering.API.Application.Models;

public class OrderSummary
{
    public int OrderNumber { get; init; }

    public DateTime Date { get; init; }

    public string Status { get; init; }

    public decimal Total { get; init; }

    public static OrderSummary FromOrder(Order order)
    {
        return new OrderSummary
        {
            OrderNumber = order.Id,
            Date = order.OrderDate,
            Status = order.OrderStatus.ToString(),
            Total = order.GetTotal()
        };
    }
}