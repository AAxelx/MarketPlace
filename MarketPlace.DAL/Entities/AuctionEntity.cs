using System;
using MarketPlace.DAL.Entities.Abstractions;
using MarketPlace.DAL.Enums;

namespace MarketPlace.DAL.Entities
{
	public class AuctionEntity : IEntity
	{
        public Guid Id { get; set; }
        public int ItemId { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime FinishedDt { get; set; }
        public decimal Price { get; set; }
        public MarketStatus Status { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }

        public virtual ItemEntity Item { get; set; }
    }
}

