using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBidding.Models
{
    public class AuctionViewModel
    {
        public HttpPostedFileBase FileBase { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Starting Price")]
        public float StartingPrice { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [Required]
        public DateTime EndDate { get; set; }
    }
}