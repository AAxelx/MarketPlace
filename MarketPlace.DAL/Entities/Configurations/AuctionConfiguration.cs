using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.DAL.Entities.Configurations
{
    public class AuctionConfiguration : IEntityTypeConfiguration<AuctionEntity>
    {
        public void Configure(EntityTypeBuilder<AuctionEntity> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.CreatedDt)
                .IsRequired();

            builder
                .Property(a => a.FinishedDt)
                .IsRequired();

            builder
                .Property(a => a.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder
                .Property(a => a.Status)
                .IsRequired()
                .HasConversion<string>();

            builder
                .Property(a => a.Seller)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(a => a.Buyer)
                .HasMaxLength(255);

            builder
                .HasOne(a => a.Item)
                .WithMany()
                .HasForeignKey(a => a.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

