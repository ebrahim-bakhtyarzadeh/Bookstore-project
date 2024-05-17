﻿using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg;

public class SellerInventory : BaseEntity
{
    public long SellerId { get; private set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? DiscountPercentage { get; private set; }

    public SellerInventory(long productId, int count, int price, int? discountPercentage = null)
    {
        if (price < 1 || count < 0)
            throw new InvalidDomainDataException("In Seller Inventory ctor , price or count is not valid !");

        ProductId = productId;
        Count = count;
        Price = price;
        DiscountPercentage = discountPercentage;
    }

    public void Edit(int count, int price, int? discountPercentage = null)
    {
        if (price < 1 || count < 0)
            throw new InvalidDomainDataException("In Seller Inventory ctor , price or count is not valid !");
        Count = count;
        Price = price;
        DiscountPercentage = discountPercentage;
    }
}