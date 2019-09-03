using POSStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSStore.Data.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder (Order order);
    }
}
