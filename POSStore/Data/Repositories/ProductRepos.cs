using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using POSStore.Data.Interfaces;
using POSStore.Data.Model;


namespace POSStore.Data.Repositories
{
    public class ProductRepos : IProduct
    {
        private readonly AppDBInfo appDBInfo;

        public ProductRepos(AppDBInfo appDBContent)
        {
            this.appDBInfo = appDBContent;
        }

        public IEnumerable<Product> products => appDBInfo.Product.Include(c => c.Categ);
        
        public IEnumerable<Product> getPopular => appDBInfo.Product.Include(c => c.Categ);
        //public IEnumerable<Product> getPopular => appDBInfo.Product.Include(pop => pop.isMostPopular).Include(cat => cat.Categ);

        public Product getProduct(int productId) => appDBInfo.Product.FirstOrDefault(p => p.id == productId);



    }
}
