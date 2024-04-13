using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class ProductReview
    {
        public int ReviewId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? Rating { get; set; }
        public string? ReviewText { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? Status { get; set; }

        public virtual Account? Customer { get; set; }
        public virtual Product? Product { get; set; }
    }
}
