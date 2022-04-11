using AlleDrogo.Domain.Entities.Auction;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AuctionMap(modelBuilder.Entity<Auction>());
            new AuctionItemMap(modelBuilder.Entity<AuctionItem>());
        }
    }
}
