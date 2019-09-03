using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POSStore.Data.Model
{
    public class StoreCart
    {
        public string StoreCartId { get; set; }

        public List<CartItem> itemStoreList { get; set; }

        private readonly AppDBInfo appDBInfo;

        public StoreCart(AppDBInfo appDBContent)
        {
            this.appDBInfo = appDBContent;
        }


        // Had this user session or not
        public static StoreCart storeCart(IServiceProvider service)
        {
            // create session
            ISession currSession = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBInfo>();

            string currCartId = currSession.GetString("CurrentCartId") ?? Guid.NewGuid().ToString();

            currSession.SetString("CurrentCartId", currCartId);

            return new StoreCart(context) { StoreCartId = currCartId };
        }

        public void AddItemToCart(Product product)
        {
            this.appDBInfo.CartItem.Add
                (new CartItem
                {
                    StoreCartId = StoreCartId,
                    product = product,
                    price = product.price,
                    amount = 1
                });

            appDBInfo.SaveChanges();
        }

        public void RemoveItemFromCart(CartItem cartItem)
        {
            this.appDBInfo.CartItem.Remove(cartItem);
            appDBInfo.SaveChanges();
        }

        public void AddAmountItem(CartItem cartItem)
        {
            this.appDBInfo.CartItem.Remove(cartItem);
            this.appDBInfo.CartItem.Add(
                new CartItem
                {
                    price = cartItem.price,
                    amount = cartItem.amount + 1,
                    product = cartItem.product,
                    StoreCartId = cartItem.StoreCartId
                });
            appDBInfo.SaveChanges();
        }

        public void RemoveAmountItem(CartItem cartItem)
        {
            this.appDBInfo.CartItem.Remove(cartItem);
            this.appDBInfo.CartItem.Add(
                new CartItem
                {
                    price = cartItem.price,
                    amount = cartItem.amount - 1,
                    product = cartItem.product,
                    StoreCartId = cartItem.StoreCartId
                });
            appDBInfo.SaveChanges();
        }

        //View products in cart
        public List<CartItem> getStoreItem()
        {
            return appDBInfo.CartItem.Where(h => h.StoreCartId == StoreCartId).Include(temp => temp.product).ToList();
        }
    }}