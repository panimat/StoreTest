using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSStore.Data.Model
{
    public class Category : ModelBase
    {
        public List<Product> products { get; set; }
    }
}
