using AlleDrogo.Domain.Entities.AppUser;
using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Infrastructure.Identity;
using AlleDrogo.Persistance.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace AlleDrogo.Infrastructure.DatabaseInitializer
{
    public class DatabaseInitializer
    {

        private readonly IRepository<Auction> repository;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public DatabaseInitializer(
            IRepository<Auction> repository, 
            RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            this.repository = repository;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.userService = userService;
        }

        public void Initialize()
        {
            PrepareUsersIfNeeded(roleManager, userManager);
            ClearItems();
            CreateItems();
        }

        private void PrepareUsersIfNeeded(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var user1 = new ApplicationUser
            {
                UserName = InitializerConstants.FirstUserData,
                Email = InitializerConstants.FirstUserData,
                EmailConfirmed = true
            };

            var result = userManager.CreateAsync(user1, "Password1!").Result;
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user1, "AppUser").Wait();
            }

            var user2 = new ApplicationUser
            {
                UserName = InitializerConstants.SecondUserData,
                Email = InitializerConstants.SecondUserData,
                EmailConfirmed = true
            };

            var result2 = userManager.CreateAsync(user2, "Password1!").Result;
            if (result2.Succeeded)
            {
                userManager.AddToRoleAsync(user2, "AppUser").Wait();
            }
        }

        private void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("AppUser").Result)
            {
                var role = new IdentityRole
                {
                    Name = "AppUser"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
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
                    userService.GetUser(InitializerConstants.FirstUserData).GetAwaiter().GetResult(),
                    DateTime.Now,
                    DateTime.Now.AddDays(7),
                    "Przedmiotem aukcji jest stary gruz opel astra",
                    2000m,
                    false,
                    false);
            var auction2 = new Auction("Buty Nike",
                    new AuctionItem("Nike AirMax 44", Category.FASHION, "Bardzo ładne nowe buty", true),
                    userService.GetUser(InitializerConstants.FirstUserData).GetAwaiter().GetResult(),
                    DateTime.Now,
                    DateTime.Now.AddDays(7),
                    "Mam do sprzedania buty",
                    199m,
                    true,
                    false);
            auction2.SetBuyNowValue(249m);

            var auction3 = new Auction("Laptop ASUS",
                    new AuctionItem("Laptop ASUS X54H", Category.ELECTRONICS, "8 Giga RAM, Grafika pięćset, dysk tysiąc", true),
                    userService.GetUser(InitializerConstants.SecondUserData).GetAwaiter().GetResult(),
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
