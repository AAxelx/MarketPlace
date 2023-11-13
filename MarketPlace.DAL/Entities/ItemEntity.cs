using MarketPlace.DAL.Entities.Abstractions;

namespace MarketPlace.DAL.Entities
{
    public class ItemEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Metadata { get; set; }
    }
}

