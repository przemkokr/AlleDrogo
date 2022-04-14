using AlleDrogo.Domain.Entities.Auction;
using AlleDrogo.Domain.Entities.Bids;
using AlleDrogo.Persistance.Mappings.Auctions;
using Microsoft.EntityFrameworkCore;

namespace AlleDrogo.Persistance.Context
{
    public  class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Auction> Auctions { get; set; }

        public DbSet<AuctionItem> AuctionItems { get; set; }

        public DbSet<ItemPhoto> ItemPhotos { get; set; }

        public DbSet<Bid> Bids { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AuctionMap(modelBuilder.Entity<Auction>());
            new AuctionItemMap(modelBuilder.Entity<AuctionItem>());
            new ItemPhotoMap(modelBuilder.Entity<ItemPhoto>());
            new BidMap(modelBuilder.Entity<Bid>());

        }
    }
}
