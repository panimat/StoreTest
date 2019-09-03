﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSStore.Data.Model
{
    public class CartItem
    {
        public int id { get; set; }
        public Product product { get; set; }
        public decimal price { get; set; }
        public int amount { get; set; }

        public string StoreCartId { get; set; }
    }
}
