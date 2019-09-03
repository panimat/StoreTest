using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSStore.Data.Model
{
    public class OrderItems
    {
        public int id { get; set; }

        public int orderId { get; set; }

        public int productId { get; set; }

        public decimal price { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public virtual Product Product { get; set; }

        public virtual Order order { get; set; }
    }
}
