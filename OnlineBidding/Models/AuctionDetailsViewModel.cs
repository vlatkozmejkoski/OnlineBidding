using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBidding.Models
{
    public class AuctionDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public float StartingPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfBidders { get; set; }
        public float HighestBid { get; set; }
        public float UserBid { get; set; }
    }
}