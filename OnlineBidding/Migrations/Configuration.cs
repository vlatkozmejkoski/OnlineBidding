namespace OnlineBidding.Migrations
{
    using OnlineBidding.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineBidding.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OnlineBidding.Models.ApplicationDbContext";
        }

        protected override void Seed(OnlineBidding.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if (!context.Auctions.Any())
            {
                List<Auction> auctions = new List<Auction>
                {
                    new Auction
                    {
                        Name = "Auction 1",
                        Category = "Random",
                        Description = "Brown, curly hair is pulled back to reveal a long, wild face. Gentle blue eyes, set narrowly within their sockets, watch wearily over the city they've rarely felt at home at for so long. A scar reaching from the left side of the foreheadrunning towards the left side of his lips and ending on his left nostril leaves a beautiful memory of his luck.",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(10),
                        Id = Guid.NewGuid(),
                        ImagePath = "https://res.cloudinary.com/dah9rmocc/image/upload/v1580074127/download_aki30f.jpg",
                        StartingPrice = 410,
                        UserId = Guid.Parse("3898d989-15a3-45bf-8262-17293bed4f35")
                    },
                    new Auction
                    {
                        Name = "Auction 2",
                        Category = "Random",
                        Description = "Brown, curly hair is pulled back to reveal a long, wild face. Gentle blue eyes, set narrowly within their sockets, watch wearily over the city they've rarely felt at home at for so long. A scar reaching from the left side of the foreheadrunning towards the left side of his lips and ending on his left nostril leaves a beautiful memory of his luck.",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(10),
                        Id = Guid.NewGuid(),
                        ImagePath = "https://res.cloudinary.com/dah9rmocc/image/upload/v1580074127/download_aki30f.jpg",
                        StartingPrice = 410,
                        UserId = Guid.Parse("3898d989-15a3-45bf-8262-17293bed4f35")
                    },
                    new Auction
                    {
                        Name = "Auction 3",
                        Category = "Random 2",
                        Description = "Brown, curly hair is pulled back to reveal a long, wild face. Gentle blue eyes, set narrowly within their sockets, watch wearily over the city they've rarely felt at home at for so long. A scar reaching from the left side of the foreheadrunning towards the left side of his lips and ending on his left nostril leaves a beautiful memory of his luck.",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(15),
                        Id = Guid.NewGuid(),
                        ImagePath = "https://res.cloudinary.com/dah9rmocc/image/upload/v1580074127/download_aki30f.jpg",
                        StartingPrice = 520,
                        UserId = Guid.Parse("3898d989-15a3-45bf-8262-17293bed4f35")
                    },
                    new Auction
                    {
                        Name = "Auction 4",
                        Category = "Random 2",
                        Description = "Brown, curly hair is pulled back to reveal a long, wild face. Gentle blue eyes, set narrowly within their sockets, watch wearily over the city they've rarely felt at home at for so long. A scar reaching from the left side of the foreheadrunning towards the left side of his lips and ending on his left nostril leaves a beautiful memory of his luck.",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(12),
                        Id = Guid.NewGuid(),
                        ImagePath = "https://res.cloudinary.com/dah9rmocc/image/upload/v1580074127/download_aki30f.jpg",
                        StartingPrice = 444,
                        UserId = Guid.Parse("3898d989-15a3-45bf-8262-17293bed4f35")
                    },
                    new Auction
                    {
                        Name = "Auction 5",
                        Category = "Random 2",
                        Description = "Brown, curly hair is pulled back to reveal a long, wild face. Gentle blue eyes, set narrowly within their sockets, watch wearily over the city they've rarely felt at home at for so long. A scar reaching from the left side of the foreheadrunning towards the left side of his lips and ending on his left nostril leaves a beautiful memory of his luck.",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(15),
                        Id = Guid.NewGuid(),
                        ImagePath = "https://res.cloudinary.com/dah9rmocc/image/upload/v1580074127/download_aki30f.jpg",
                        StartingPrice = 331,
                        UserId = Guid.Parse("3898d989-15a3-45bf-8262-17293bed4f35")
                    },
                    new Auction
                    {
                        Name = "Auction 6",
                        Category = "Random",
                        Description = "Brown, curly hair is pulled back to reveal a long, wild face. Gentle blue eyes, set narrowly within their sockets, watch wearily over the city they've rarely felt at home at for so long. A scar reaching from the left side of the foreheadrunning towards the left side of his lips and ending on his left nostril leaves a beautiful memory of his luck.",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(15),
                        Id = Guid.NewGuid(),
                        ImagePath = "https://res.cloudinary.com/dah9rmocc/image/upload/v1580074127/download_aki30f.jpg",
                        StartingPrice = 420,
                        UserId = Guid.Parse("3898d989-15a3-45bf-8262-17293bed4f35")
                    }
                };

                context.Auctions.AddRange(auctions);
                context.SaveChanges();
            }
        }
    }
}
