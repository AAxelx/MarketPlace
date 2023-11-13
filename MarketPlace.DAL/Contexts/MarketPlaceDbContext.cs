using MarketPlace.DAL.Entities;
using MarketPlace.DAL.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL.Contexts
{
    public class MarketPlaceDbContext : DbContext
    {
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<AuctionEntity> Auctions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new AuctionConfiguration());
        }
    }

}

