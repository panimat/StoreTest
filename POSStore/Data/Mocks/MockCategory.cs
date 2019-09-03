using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using POSStore.Data.Interfaces;
using POSStore.Data.Model;

namespace POSStore.Data.Mocks
{
    public class MockCategory : IProductCategory
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category> {
                    new Category { id = 1, name = "POS terminal" },
                    new Category { id = 2, name = "Printers" }
                };
            }
        }
    }
}
