using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using POSStore.Data.Model;

namespace POSStore.Data.Interfaces
{
    public interface IProductCategory
    {
        IEnumerable<Category> Categories { get; }
    }
}
