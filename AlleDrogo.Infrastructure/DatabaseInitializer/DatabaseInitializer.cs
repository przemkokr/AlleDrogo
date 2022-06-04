using AlleDrogo.Domain.Entities.AppUser;
using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Persistance.Repository;
using System;
using System.Linq;

namespace AlleDrogo.Infrastructure.DatabaseInitializer
{
    public class DatabaseInitializer
    {

        private readonly IRepository<Auction> repository;

        public DatabaseInitializer(IRepository<Auction> repository)
        {
            this.repository = repository;
        }

        public void Initialize()
        {
            ClearItems();
            CreateItems();
        }

        private void ClearItems()
        {
            var auctions = repository.GetAll();
            foreach (var item in auctions)
            {
                repository.Delete(item);
            }

            repository.SaveChanges();
        }

        private void CreateItems()
        {
            var auction1 = new Auction("Opel Astra III zadbany",
                    new AuctionItem("Opel Astra III 1.5 LPG", Category.CARS, "Zadbany opelek prosto od handlarza", false),
                    new ApplicationUser { UserName = "Tom Gruz", Email = "tom.gruz@null.exception"},
                    DateTime.Now,
                    DateTime.Now.AddDays(7),
                    "Przedmiotem aukcji jest stary gruz opel astra",
                    2000m,
                    false,
                    false);
            var auction2 = new Auction("Buty Nike",
                    new AuctionItem("Nike AirMax 44", Category.FASHION, "Bardzo ładne nowe buty", true),
                    new ApplicationUser { UserName = "Anna Wanna", Email = "wannaanna2@gmail.com"},
                    DateTime.Now,
                    DateTime.Now.AddDays(7),
                    "Mam do sprzedania buty",
                    199m,
                    true,
                    false);
            auction2.SetBuyNowValue(249m);

            var auction3 = new Auction("Laptop ASUS",
                    new AuctionItem("Laptop ASUS X54H", Category.ELECTRONICS, "8 Giga RAM, Grafika pięćset, dysk tysiąc", true),
                    new ApplicationUser { UserName = "Sam Drabulok", Email = "sandra.bullock@gmail.com"},
                    DateTime.Now,
                    DateTime.Now.AddDays(10),
                    "Super laptop dla graczy",
                    1488m,
                    true,
                    false);
            auction3.SetBuyNowValue(1800m);

            var auctions = new Auction[]
            {
                auction1, auction2, auction3
            };

            var existingAuctions = this.repository.GetAll();
            if (existingAuctions.Count() < 3)
            {
                foreach (var auction in auctions)
                {
                    this.repository.Add(auction);
                }

                this.repository.SaveChanges();
            }
        }
    }
}
