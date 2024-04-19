using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public string? FeedbackText { get; set; }
        public DateTime? FeedbackDate { get; set; }

        public virtual Account? Customer { get; set; }
        public virtual Product? Product { get; set; }
    }
}
