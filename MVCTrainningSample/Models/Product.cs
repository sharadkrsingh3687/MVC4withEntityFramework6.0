using System;
using System.Collections.Generic;

namespace MVCTrainningSample.Models
{
    public partial class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Type { get; set; }
    }
}
