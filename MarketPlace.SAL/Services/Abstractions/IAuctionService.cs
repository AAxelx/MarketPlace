using MarketPlace.SAL.Common;
using MarketPlace.SAL.Models;

namespace MarketPlace.SAL.Services.Abstractions
{
    public interface IAuctionService
    {
        Task<ServiceResponse<List<Auction>>> GetAllAuctions();
        Task<ServiceResponse<Auction>> GetAuctionById(Guid id);
        //Task<ServiceResponse<List<Item>>> GetItemsWithFilter(FilterModel filterModel);
        Task<ServiceResponse<Auction>> AddAuction(Auction auction);
        Task<ServiceResponse<Auction>> UpdateAuction(Auction auction);
        Task<ServiceResponse<Auction>> DeleteAuction(Guid id);
    }

}

