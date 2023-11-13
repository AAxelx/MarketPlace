using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.DAL.Entities.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<ItemEntity>
    {
        public void Configure(EntityTypeBuilder<ItemEntity> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(i => i.Description)
                .HasMaxLength(1000);

            builder
                .Property(i => i.Metadata)
                .HasMaxLength(500);
        }
    }
}

