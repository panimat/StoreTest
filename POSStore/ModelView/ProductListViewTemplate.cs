using POSStore.Data.Model;
using System.Collections.Generic;


namespace POSStore.ModelView
{
    public class ProductListViewTemplate
    {
        public IEnumerable<Product> GetProduct { get; set; }

        public string productCategory;
    }
}
