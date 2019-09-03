using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using POSStore.Data.Interfaces;
using POSStore.Data.Model;

namespace POSStore.Data.Mocks
{
    public class MockProducts : IProduct
    {
        private readonly IProductCategory _categProd = new MockCategory();

        public IEnumerable<Product> products
        {
            get
            {
                return new List<Product> {
                    new Product { id = 1, name = "MappleTouch", description = "blablabla", img = "/images/mapletouch.jpg", price = 1000, isAvailable = true, categ = _categProd.Categories.First() },
                    new Product { id = 1, name = "Citizen", description = "blablabla", img = "/images/rongta.jpg", price = 2000, isAvailable = true, categ = _categProd.Categories.Last() },
                };
            }
        }

        public IEnumerable<Product> setCategProd { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Product getProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
