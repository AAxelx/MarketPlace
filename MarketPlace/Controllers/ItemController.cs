using MarketPlace.API.Contracts;
using MarketPlace.SAL.Common;
using MarketPlace.SAL.Models;
using MarketPlace.SAL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [ApiController]
    [Route("api/v0.1/items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Item>>>> GetItems()
        {
            var response = await _itemService.GetAllItems();
            LogResponse("GetItems", response);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Item>>> GetItemById(Guid id)
        {
            var response = await _itemService.GetItemById(id);
            LogResponse($"GetItemById - ID: {id}", response);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        //[HttpGet("filter")]
        //public async Task<ActionResult<ServiceResponse<List<Item>>>> GetItemsWithFilter([FromQuery] FilterModelRequest filterModelRequest)
        //{
        //    var response = await _itemService.GetItemsWithFilter(filterModelRequest.Name, filterModelRequest.Status, filterModelRequest.SortOrder, filterModelRequest.SortKey, filterModelRequest.Limit);
        //    LogResponse($"GetItemsWithFilter - Name: {filterModelRequest.Name}, Status: {filterModelRequest.Status}, SortOrder: {filterModelRequest.SortOrder}, SortKey: {filterModelRequest.SortKey}, Limit: {filterModelRequest.Limit}", response);
        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Item>>> AddItem(Item item)
        {
            var response = await _itemService.AddItem(item);
            LogResponse($"AddItem - Name: {item.Name}", response);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Item>>> UpdateItem(Item item)
        {
            var response = await _itemService.UpdateItem(item);
            //LogResponse($"UpdateItem - ID: {id}, Name: {item.Name}", response);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Item>>> DeleteItem(Guid id)
        {
            var response = await _itemService.DeleteItem(id);
            LogResponse($"DeleteItem - ID: {id}", response);

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

