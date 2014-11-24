using System;
using System.Collections.Generic;

namespace MVCTrainningSample.Models
{
    public partial class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
