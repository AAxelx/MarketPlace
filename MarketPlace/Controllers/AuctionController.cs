using MarketPlace.API.Contracts;
using MarketPlace.SAL.Common;
using MarketPlace.SAL.Models;
using MarketPlace.SAL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [ApiController]
    [Route("api/v0.1/auctions")]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;
        private readonly ILogger<AuctionController> _logger;

        public AuctionController(IAuctionService auctionService, ILogger<AuctionController> logger)
        {
            _auctionService = auctionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Auction>>>> GetAuctions()
        {
            var response = await _auctionService.GetAllAuctions();
            LogResponse("GetAuctions", response);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Auction>>> GetAuctionById(Guid id)
        {
            var response = await _auctionService.GetAuctionById(id);
            LogResponse($"GetAuctionById - ID: {id}", response);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        //[HttpGet("filter")]
        //public async Task<ActionResult<ServiceResponse<List<Auction>>>> GetAuctionsWithFilter([FromQuery] FilterModelRequest filterModelRequest)
        //{
        //    var response = await _auctionService.GetAuctionsWithFilter(filterModelRequest.Name, filterModelRequest.Status, filterModelRequest.SortOrder, filterModelRequest.SortKey, filterModelRequest.Limit);
        //    LogResponse($"GetAuctionsWithFilter - Name: {filterModelRequest.Name}, Status: {filterModelRequest.Status}, SortOrder: {filterModelRequest.SortOrder}, SortKey: {filterModelRequest.SortKey}, Limit: {filterModelRequest.Limit}", response);
        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Auction>>> AddAuction(Auction auction)
        {
            var response = await _auctionService.AddAuction(auction);
            //LogResponse($"AddAuction - Name: {auction.Name}", response);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Auction>>> UpdateAuction(Guid id, Auction auction)
        {
            var response = await _auctionService.UpdateAuction(auction);
            //LogResponse($"UpdateAuction - ID: {id}, Name: {auction.Name}", response);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Auction>>> DeleteAuction(Guid id)
        {
            var response = await _auctionService.DeleteAuction(id);
            LogResponse($"DeleteAuction - ID: {id}", response);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        private void LogResponse<T>(string methodName, ServiceResponse<T> response)
        {
            if (response.Success)
            {
                _logger.LogInformation($"{methodName} - Success: {response.Success}");
            }
            else
            {
                _logger.LogError($"{methodName} - Success: {response.Success}, Message: {response.Message}");
            }
        }
    }

}

