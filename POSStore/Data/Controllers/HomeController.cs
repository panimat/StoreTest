using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSStore.Data.Interfaces;
using POSStore.ModelView;

namespace POSStore.Data.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _productI;

        public HomeController(IProduct productI)
        {
            _productI = productI;
        }

        public ViewResult Index()
        {
            var popularProd = new HomeViewModel
            {
                popularProduct = _productI.getPopular
            };

            return View(popularProd);
        }
    }
}