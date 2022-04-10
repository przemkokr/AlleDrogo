using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlleDrogo.Internal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionController : ControllerBase
    {
        private Auction[] auctions;

        public AuctionController()
        {
            this.GetAuctionsMockup();
        }

        private void GetAuctionsMockup()
        {
            this.auctions = new Auction[]
            {
                new Auction
                {
                    Title = "Opel Astra III zadbany",
                    Item = new Item
                    {
                        Name = "Opel Astra III 1.5 LPG",
                        Category = "Samochody",
                        Description = "Zadbany opelek prosto od handlarza",
                        IsNew = false
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Description = "Przedmiotem aukcji jest stary gruz opel astra",
                    CurrentValue = 2000m,
                    IsBuyNow = false
                },
                new Auction
                {
                    Title = "Buty Nike",
                    Item = new Item
                    {
                        Name = "Nike AirMax 44",
                        Category = "Odzież",
                        Description = "Bardzo ładne nowe buty",
                        IsNew = true
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Description = "Mam do sprzedania buty",
                    CurrentValue = 199m,
                    BuyNowValue = 299m,
                    IsBuyNow = true
                },
                new Auction
                {
                    Title = "Laptop ASUS",
                    Item = new Item
                    {
                        Name = "Laptop ASUS X54H",
                        Category = "Elektronika",
                        Description = "8 Giga RAM, Grafika pięćset, dysk tysiąc",
                        IsNew = true
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(10),
                    Description = "Super laptop dla graczy",
                    CurrentValue = 1488m,
                    BuyNowValue = 1999m,
                    IsBuyNow = true
                }
            };
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IEnumerable<Auction>> GetAuctions()
        {
            await Task.CompletedTask;

            return auctions;
        }
    }

    public class Auction
    {
        public string Title { get; set; }

        public Item Item { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public decimal CurrentValue { get; set; }

        public bool IsBuyNow { get; set; }

        public decimal? BuyNowValue { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public bool IsNew { get; set; }
    }
}
