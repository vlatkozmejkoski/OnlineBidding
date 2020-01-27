using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBidding.Models
{
    public class BidModel
    {
        [Required]
        public Guid AuctionId { get; set; }
        [Required]
        public float BidPrice { get; set; }
    }
}