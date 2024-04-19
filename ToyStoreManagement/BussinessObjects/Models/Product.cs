using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Product
    {
        public Product()
        {
            Feedbacks = new HashSet<Feedback>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductReviews = new HashSet<ProductReview>();
            ProductUrls = new HashSet<ProductUrl>();
        }

        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
        public string? PhotoUrlThumnail { get; set; }
        public int? CategoryId { get; set; }
        public int? Status { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ICollection<ProductUrl> ProductUrls { get; set; }
    }
}
