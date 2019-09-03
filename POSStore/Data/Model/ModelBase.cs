using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSStore.Data.Model
{
    public class ModelBase
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string img { get; set; } // url image
    }
}
