using ListR.Common.Interfaces.Repositories;
using ListR.DataLayer.EntityModels.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListR.Repositories.ShoppingLists
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        public Task CreateShopList(ShopList model)
        {
            throw new NotImplementedException();
        }

        public List<ShopList> GetallByUser(string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}
