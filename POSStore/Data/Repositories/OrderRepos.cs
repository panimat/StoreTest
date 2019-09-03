using POSStore.Data.Interfaces;
using POSStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSStore.Data.Repositories
{
    public class OrderRepos : IAllOrders
    {
        private readonly AppDBInfo _appDBInfo;
        private readonly StoreCart _storeCart;

        public OrderRepos(AppDBInfo appDbInfo, StoreCart storeCart)
        {
            _appDBInfo = appDbInfo;
            _storeCart = storeCart;
        }

        public void CreateOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            _appDBInfo.Order.Add(order);

            var items = _storeCart.itemStoreList;

            foreach(var el in items)
            {
                var orderItems = new OrderItems
                {
                    productId = el.id,
                    orderId = order.id,
                    price = el.price
                };

                _appDBInfo.OrderItems.Add(orderItems);
            }

            _appDBInfo.SaveChanges();
        }
    }
}
