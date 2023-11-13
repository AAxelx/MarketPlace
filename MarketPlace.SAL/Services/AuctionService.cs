using AutoMapper;
using MarketPlace.DAL.Entities;
using MarketPlace.DAL.Repositories.Abstractions;
using MarketPlace.SAL.Common;
using MarketPlace.SAL.Models;
using MarketPlace.SAL.Services.Abstractions;

namespace MarketPlace.SAL.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IDbRepository<AuctionEntity> _auctionRepository;
        private readonly IMapper _mapper;

        public AuctionService(IDbRepository<AuctionEntity> auctionRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Auction>>> GetAllAuctions()
        {
            var auctionsEntities = await _auctionRepository.GetAll();
            var auctions = _mapper.Map<List<Auction>>(auctionsEntities);
            return new ServiceResponse<List<Auction>>(auctions, true);
        }

        public async Task<ServiceResponse<Auction>> GetAuctionById(Guid id)
        {
            var auctionEntity = await _auctionRepository.GetById(id);

            if (auctionEntity == null)
            {
                return new ServiceResponse<Auction>(false, "Auction not found");
            }

            var auction = _mapper.Map<Auction>(auctionEntity);
            return new ServiceResponse<Auction>(auction, true);
        }

        //public async Task<ServiceResponse<List<Auction>>> GetItemsWithFilter(FilterModel filterModel)
        //{
        //    var filteredItems = await _auctionRepository.GetAuctionsWithFilter(filterModel.Name, filterModel.Status, filterModel.SortOrder, filterModel.SortKey, filterModel.Limit);

        //    return new ServiceResponse<List<Auction>> { Data = filteredItems, Success = true };
        //}

        public async Task<ServiceResponse<Auction>> AddAuction(Auction auction)
        {
            var auctionEntity = _mapper.Map<AuctionEntity>(auction);
            await _auctionRepository.Add(auctionEntity);

            return new ServiceResponse<Auction>(auction, true);
        }

        public async Task<ServiceResponse<Auction>> UpdateAuction(Auction auction)
        {
            var existingAuctionEntity = await _auctionRepository.GetById(auction.Id);

            if (existingAuctionEntity == null)
            {
                return new ServiceResponse<Auction>(false, "Auction not found");
            }

            _mapper.Map(auction, existingAuctionEntity);
            await _auctionRepository.Update(existingAuctionEntity);

            return new ServiceResponse<Auction>(auction, true);
        }

        public async Task<ServiceResponse<Auction>> DeleteAuction(Guid id)
        {
            var auctionEntity = await _auctionRepository.GetById(id);

            if (auctionEntity == null)
            {
                return new ServiceResponse<Auction>(false, "Auction not found");
            }

            await _auctionRepository.Delete(auctionEntity);
            var auction = _mapper.Map<Auction>(auctionEntity);

            return new ServiceResponse<Auction>(auction, true);
        }
    }

}

