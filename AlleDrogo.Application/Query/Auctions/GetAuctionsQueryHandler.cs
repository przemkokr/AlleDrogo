using AlleDrogo.Domain.Entities.Auction;
using AlleDrogo.Internal.Contracts.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AlleDrogo.Application.Query.Auctions
{
    public class GetAuctionsQueryHandler : IRequestHandler<GetAuctionsQuery, IEnumerable<Auction>>
    {
        public async Task<IEnumerable<Auction>> Handle(GetAuctionsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var auctions = new Auction[]
            {
                new Auction("Opel Astra III zadbany",
                    new AuctionItem("Opel Astra III 1.5 LPG", "Samochody", "Zadbany opelek prosto od handlarza", false),
                    DateTime.Now,
                    DateTime.Now.AddDays(7),
                    "Przedmiotem aukcji jest stary gruz opel astra",
                    2000m,
                    false),
                new Auction("Buty Nike",
                    new AuctionItem("Nike AirMax 44", "Odzież", "Bardzo ładne nowe buty", true),
                    DateTime.Now,
                    DateTime.Now.AddDays(7),
                    "Mam do sprzedania buty",
                    199m,
                    true),                
                new Auction("Laptop ASUS",
                    new AuctionItem("Laptop ASUS X54H", "Elektronika", "8 Giga RAM, Grafika pięćset, dysk tysiąc", true),                                       
                    DateTime.Now,
                    DateTime.Now.AddDays(10),
                    "Super laptop dla graczy",
                    1488m,                    
                    true)                
            };

            return auctions;
        }
    }
}
