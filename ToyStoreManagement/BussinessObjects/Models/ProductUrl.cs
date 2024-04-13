using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class ProductUrl
    {
        public int ProductUrlId { get; set; }
        public int? ProductId { get; set; }
        public string? ProductUrl1 { get; set; }

        public virtual Product? Product { get; set; }
    }
}
