using AutoMapper;
using MarketPlace.DAL.Entities;
using MarketPlace.DAL.Repositories.Abstractions;
using MarketPlace.SAL.Common;
using MarketPlace.SAL.Models;
using MarketPlace.SAL.Services.Abstractions;

namespace MarketPlace.SAL.Services
{
    public class ItemService : IItemService
    {
        private readonly IDbRepository<ItemEntity> _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IDbRepository<ItemEntity> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Item>>> GetAllItems()
        {
            var itemsEntities = await _itemRepository.GetAll();
            var items = _mapper.Map<List<Item>>(itemsEntities);
            return new ServiceResponse<List<Item>>(items, true);
        }

        public async Task<ServiceResponse<Item>> GetItemById(Guid id)
        {
            var itemEntity = await _itemRepository.GetById(id);

            if (itemEntity == null)
            {
                return new ServiceResponse<Item>(false, "Item not found");
            }

            var item = _mapper.Map<Item>(itemEntity);
            return new ServiceResponse<Item>(item, true);
        }

        //public async Task<ServiceResponse<List<Item>>> GetItemsWithFilter(FilterModel filterModel)
        //{
        //    var filteredItems = await _itemRepository.GetItemsWithFilter(filterModel.Name, filterModel.Status, filterModel.SortOrder, filterModel.SortKey, filterModel.Limit);

        //    return new ServiceResponse<List<Item>> { Data = filteredItems, Success = true };
        //}

        public async Task<ServiceResponse<Item>> AddItem(Item item)
        {
            var itemEntity = _mapper.Map<ItemEntity>(item);
            await _itemRepository.Add(itemEntity);

            return new ServiceResponse<Item>(item, true);
        }

        public async Task<ServiceResponse<Item>> UpdateItem(Item item)
        {
            var existingItemEntity = await _itemRepository.GetById(item.Id);

            if (existingItemEntity == null)
            {
                return new ServiceResponse<Item>(false, "Item not found");
            }

            _mapper.Map(item, existingItemEntity);
            await _itemRepository.Update(existingItemEntity);

            return new ServiceResponse<Item>(item, true);
        }

        public async Task<ServiceResponse<Item>> DeleteItem(Guid id)
        {
            var itemEntity = await _itemRepository.GetById(id);

            if (itemEntity == null)
            {
                return new ServiceResponse<Item>(false, "Item not found");
            }

            await _itemRepository.Delete(itemEntity);
            var item = _mapper.Map<Item>(itemEntity);

            return new ServiceResponse<Item>(item, true);
        }
    }

}

