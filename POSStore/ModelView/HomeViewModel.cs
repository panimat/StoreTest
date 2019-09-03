using POSStore.Data.Model;
using System.Collections.Generic;

namespace POSStore.ModelView
{
    public class HomeViewModel
    {
        public IEnumerable<Product> popularProduct { get; set; }
    }
}
