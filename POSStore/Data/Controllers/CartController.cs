using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSStore.Data.Model;
using POSStore.Data.Interfaces;
using POSStore.ModelView;

namespace POSStore.Data.Controllers
{
    public class CartController : Controller
    {
        private readonly IProduct _productI;
        private readonly StoreCart _storeCart;

        public CartController(IProduct productI, StoreCart storeCart)
        {
            _productI = productI;
            _storeCart = storeCart;
        }

        public ViewResult Index()
        {
            var itemsList = _storeCart.getStoreItem();
            _storeCart.itemStoreList = itemsList;

            var temp = new CartViewModel { stCart = _storeCart };

            return View(temp);
        }

        public RedirectToActionResult addToCart(int id)
        {
            // add product with given id
            var item = _productI.products.FirstOrDefault(ind => ind.id == id);

            if (item != null)
            {
                if (_storeCart.getStoreItem().Where(it => it.product.id == id).Count() != 0)
                    _storeCart.AddAmountItem((CartItem)_storeCart.getStoreItem().Where(it => it.product.id == id).ToList()[0]);
                else
                    _storeCart.AddItemToCart(item);
            }
            
            return RedirectToAction("Index");
        }

        public RedirectToActionResult removeFromCart(int id)
        {
            // 
            var item = _productI.products.FirstOrDefault(ind => ind.id == id);

            if (item != null)
            {
                if (_storeCart.getStoreItem().Where(it => it.product.id == id).Count() != 0)
                    _storeCart.RemoveAmountItem((CartItem)_storeCart.getStoreItem().Where(it => it.product.id == id).ToList()[0]);
            }

            if (_storeCart.getStoreItem().Where(it => it.product.id == id).ToList()[0].amount <= 0)
                _storeCart.RemoveItemFromCart((CartItem)_storeCart.getStoreItem().Where(it => it.product.id == id).ToList()[0]);
            
            return RedirectToAction("Index");
        }
    }
}