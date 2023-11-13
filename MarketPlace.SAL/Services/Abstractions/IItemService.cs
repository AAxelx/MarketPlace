using MarketPlace.SAL.Common;
using MarketPlace.SAL.Models;

namespace MarketPlace.SAL.Services.Abstractions
{
    public interface IItemService
    {
        Task<ServiceResponse<List<Item>>> GetAllItems();
        Task<ServiceResponse<Item>> GetItemById(Guid id);
        //Task<ServiceResponse<List<Item>>> GetItemsWithFilter(FilterModel filterModel);
        Task<ServiceResponse<Item>> AddItem(Item item);
        Task<ServiceResponse<Item>> UpdateItem(Item item);
        Task<ServiceResponse<Item>> DeleteItem(Guid id);
    }

}

