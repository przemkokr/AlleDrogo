using AlleDrogo.Domain.Entities.Auction;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace AlleDrogo.Domain.Entities.AppUser
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Rating> ListOfRatings { get; protected set; }

        public double Rating
        {
            get
            {
                double averageRating = 0;
                foreach (var rating in this.ListOfRatings)
                {
                    averageRating += rating.RatingPoints;
                }
                return averageRating / ListOfRatings.Count();
            }
        }
    }

}

