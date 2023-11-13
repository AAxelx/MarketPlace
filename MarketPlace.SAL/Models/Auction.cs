using MarketPlace.SAL.Models.Enums;

namespace MarketPlace.SAL.Models
{
    public class Auction
    {
        public Guid Id { get; set; }
        public int ItemId { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime FinishedDt { get; set; }
        public decimal Price { get; set; }
        public MarketStatus Status { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
    }
}

