using System;
using System.Collections.Generic;

namespace Bai1.Models
{
    public partial class Product
    {
        public decimal Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Status { get; set; }
        public decimal? Categoryid { get; set; }
        public DateTime? Createdate { get; set; }
    }
}
