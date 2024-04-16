using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
		public string? Address { get; set; }
		public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? Status { get; set; }

        public virtual Account? Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
