using AlleDrogo.Domain.Entities.AppUser;
using AlleDrogo.Domain.Entities.Auction;
using AlleDrogo.Domain.Entities.Bids;
using AlleDrogo.Persistance.Mappings.Auctions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AlleDrogo.Persistance.Context
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
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
