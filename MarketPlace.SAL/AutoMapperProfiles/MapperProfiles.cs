using AutoMapper;
using MarketPlace.DAL.Entities;
using MarketPlace.SAL.Models;

namespace MarketPlace.SAL.AutoMapperProfiles
{
	public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Item, ItemEntity>().ReverseMap();
            CreateMap<Auction, AuctionEntity>().ReverseMap();
        }
    }
}

