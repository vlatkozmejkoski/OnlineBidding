using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBidding.Models.Entities
{
    public class Bidding
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid AuctionId { get; set; }
        public Auction Auction { get; set; }
        public float BidPrice { get; set; }
    }
}