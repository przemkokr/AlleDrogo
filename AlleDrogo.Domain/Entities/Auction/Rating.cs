using AlleDrogo.Domain.Entities.AppUser;
using AlleDrogo.Domain.Entities.Base;
namespace AlleDrogo.Domain.Entities.Auction
{
    public class Rating : EntityBase
    {
        protected Rating()
        {
        }

        public Rating(double ratingPoints, Auction auction, ApplicationUser evaluator, ApplicationUser evaluatedUser)
        {
            RatingPoints = ratingPoints;
            Auction = auction;
            Evaluator = evaluator;
            EvaluatedUser = evaluatedUser;
        }
        public double RatingPoints { get; protected set; }
        public Auction Auction { get; protected set; }
        public ApplicationUser Evaluator { get; protected set; }
        public ApplicationUser EvaluatedUser { get; protected set; }
    }

}
