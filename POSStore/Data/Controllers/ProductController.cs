using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using POSStore.Data.Interfaces;
using POSStore.ModelView;
using POSStore.Data.Model;
using System.Linq;

namespace POSStore.Data.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _products;
        private readonly IProductCategory _prodCateg;

        public ProductController(IProduct _iprod, IProductCategory _iprodCateg)
        {
            _products = _iprod;
            _prodCateg = _iprodCateg;
        }

        [Route("Product/List")]
        [Route("Product/List/{category}")]
        public ViewResult List(string category)
        {
            var _category = category;

            IEnumerable<Product> products = null;
            string currCategory;

            if (String.IsNullOrEmpty(_category))
                products = _products.products.OrderBy(i => i.id);
            else
            {
                if (String.Equals("POS терминалы", _category, StringComparison.OrdinalIgnoreCase))
                    products = _products.products.Where(i => i.Categ.name.Equals("POS терминалы"));
                else if (String.Equals("POS принтеры", _category, StringComparison.OrdinalIgnoreCase))
                    products = _products.products.Where(i => i.Categ.name.Equals("POS принтеры"));
            }

            currCategory = _category;

            ViewBag.Title = "StartPage";

            var obj = new ProductListViewTemplate
            {
                GetProduct = products,
                productCategory = currCategory
            };

            return View(obj);
        }
    }
}