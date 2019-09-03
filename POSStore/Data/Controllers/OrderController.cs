using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSStore.Data.Interfaces;
using POSStore.Data.Model;

namespace POSStore.Data.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly StoreCart _storeCart;

        public OrderController(IAllOrders allOrders, StoreCart storeCart)
        {
            _allOrders = allOrders;
            _storeCart = storeCart;
        }


        public IActionResult CheckData(Order currOrder)
        {            
            _storeCart.itemStoreList = _storeCart.getStoreItem();

            if (_storeCart.itemStoreList.Count == 0)
                ModelState.AddModelError("11111111", "Корзина пуста");
            
            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(currOrder);
                return RedirectToAction("Success");
            }
            
            return View(currOrder);

        }

        public IActionResult Success()
        {
            ViewBag.Message = "Ваш заказ принят. Менеджер свяжеться с Вами.";

            return View();
        }
    }
}