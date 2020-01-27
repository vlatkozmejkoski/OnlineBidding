using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Firebase.Storage;
using Microsoft.AspNet.Identity;
using OnlineBidding.Models;
using OnlineBidding.Models.Entities;

namespace OnlineBidding.Controllers
{
    public class AuctionsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private Cloudinary _cloudinary { get; set; }

        public AuctionsController()
        {
            var account = new Account("dah9rmocc", "353854462212833", "pS_mDiCKa4b5gOS7R2xmFPKPbA0");
            _cloudinary = new Cloudinary(account);
        }

        // GET: Auctions
        public ActionResult Index()
        {
            return View(db.Auctions.ToList());
        }

        // GET: Auctions/Details/5
        public ActionResult Details(Guid? id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            var auctionBids = db.Biddings.Where(x => x.AuctionId == auction.Id);
            var viewModel = new AuctionDetailsViewModel()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                EndDate = auction.EndDate,
                StartingPrice = auction.StartingPrice,
                ImagePath = auction.ImagePath,
                StartDate = auction.StartDate,
            };

            if (auctionBids.Any())
            {
                viewModel.NumberOfBidders = auctionBids.GroupBy(x => x.UserId).Count();
                viewModel.HighestBid = auctionBids.Max(x => x.BidPrice);
                viewModel.UserBid = auctionBids.FirstOrDefault(x => x.UserId == userId).BidPrice;
            }
            ViewData["AuctionDetails"] = viewModel;
            ViewData["UserId"] = userId;


            return View(new BidModel());
        }

        public ActionResult MyAuctions()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var viewModel = db.Auctions.Where(x => x.UserId == userId).ToList();
            return View(viewModel);
        }

        // GET: Auctions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auctions/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuctionViewModel auction)
        {
            if (ModelState.IsValid)
            {
                var img = auction.FileBase;
                var imgParams = new ImageUploadParams
                {
                    File = new FileDescription(img.FileName, img.InputStream)
                };

                var result = _cloudinary.Upload(imgParams);
                
                var entity = new Auction()
                {
                    Id = Guid.NewGuid(),
                    Description = auction.Description,
                    EndDate = auction.EndDate,
                    Name = auction.Name,
                    StartDate = auction.StartDate,
                    StartingPrice = auction.StartingPrice,
                    ImagePath = result.Uri.ToString(),
                    UserId = Guid.Parse(User.Identity.GetUserId())
                };

                db.Auctions.Add(entity);
                db.SaveChanges();
                return RedirectToAction("MyAuctions");
            }

            return View(auction);
        }

        // GET: Auctions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // POST: Auctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartingPrice,StartDate,EndDate")] Auction auction)
        {
            var anyBids = db.Biddings.Any(x => x.AuctionId == auction.Id);
            if (anyBids)
            {
                ModelState.AddModelError("","The auction has at least 1 bid and cannot be edited.");
            }

            if (ModelState.IsValid)
            {
                db.Entry(auction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bid(BidModel model)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bidding = new Bidding
            {
                Id = Guid.NewGuid(),
                AuctionId = model.AuctionId,
                UserId = userId ,
                BidPrice = model.BidPrice
            };

            var existingBid = db.Biddings.FirstOrDefault(x => x.UserId == userId);

            if(existingBid != default)
            {
                existingBid.BidPrice = model.BidPrice;
                db.Entry(existingBid).State = EntityState.Modified;
            }
            else
            {
                db.Biddings.Add(bidding);
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Auctions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // POST: Auctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Auction auction = db.Auctions.Find(id);
            db.Auctions.Remove(auction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
