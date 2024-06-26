﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "order");

            builder.OwnsOne(b => b.Discount, option =>
            {
                option.Property(d => d.DiscountTitle)
                    .HasMaxLength(50);
            });


            builder.OwnsOne(b => b.ShippingMethod, option =>
            {
                option.Property(d => d.ShippingType)
                    .HasMaxLength(50);
            });

            builder.OwnsMany(b => b.Items, option =>
            {
                option.ToTable("Items", "order");

            });

            builder.OwnsOne(b => b.Address, option =>
            {
                option.ToTable("Addresses", "order");
                option.HasKey(b => b.Id);

                option.Property(b => b.City)
                    .HasMaxLength(50)
                    .IsRequired();
                option.Property(b => b.PhoneNumber)
                    .HasMaxLength(11)
                    .IsRequired();
                option.Property(b => b.LastName)
                    .HasMaxLength(100)
                    .IsRequired();
                option.Property(b => b.FirstName)
                    .HasMaxLength(100)
                    .IsRequired();
                option.Property(b => b.NationalCode)
                    .HasMaxLength(11)
                    .IsRequired();
                option.Property(b => b.PostalCode)
                    .HasMaxLength(40)
                    .IsRequired();

            });
        }
    }
}
