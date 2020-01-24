using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBidding.Models.Entities
{
    public class Auction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float StartingPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }
    }
}