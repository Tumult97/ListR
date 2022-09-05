using ListR.DataLayer.EntityModels.Lists;

namespace ListR.Common.Interfaces.Repositories
{
    public interface IShoppingListRepository
    {
        public Task CreateShopList(ShopList model);
    }
}
