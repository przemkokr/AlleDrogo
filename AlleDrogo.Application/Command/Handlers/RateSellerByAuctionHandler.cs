using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Infrastructure.Identity;
using AlleDrogo.Internal.Contracts.Command;
using AlleDrogo.Persistance.Repository;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace AlleDrogo.Application.Command.Handlers
{
    public class RateSellerByAuctionHandler : IRequestHandler<RateSellerByAuctionCommand, int>
    {
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IRepository<Auction> _auctionRepository;
        private readonly IUserService _userRepository;

        public RateSellerByAuctionHandler(IRepository<Rating> ratingRepository, IRepository<Auction> auctionRepository, IUserService userRepository)
        {
            this._ratingRepository = ratingRepository;
            this._auctionRepository = auctionRepository;
            this._userRepository = userRepository;
        }
        public async Task<int> Handle(RateSellerByAuctionCommand request, CancellationToken cancellationToken)
        {
            if(request.RateSeller.RatingPoints < 1 || request.RateSeller.RatingPoints > 6)
            {
                throw new ValidationException("Ocena z jest z poza zakresu <1, 6>");
            }


            var auction = _auctionRepository.GetById(request.RateSeller.AuctionId);
            if (auction == null)
            {
                throw new ValidationException("Nie znaleziono aukcji. Prawdopodobnie została zakończona w czasie, kiedy licytowałeś.");
            }

            var seller = await _userRepository.GetUser(auction.User.UserName);
            if (seller == null)
            {
                throw new ValidationException("Nie znaleziono użytkownika!");
            }

            var evaluator = await _userRepository.GetUser(request.RateSeller.EvaluatorUserName);
            if (evaluator == null)
            {
                throw new ValidationException("Nie znaleziono użytkownika!");
            }

            var rating = new Rating(
                request.RateSeller.RatingPoints, 
                auction, 
                evaluator, 
                seller);

            _ratingRepository.Add(rating);
            _ratingRepository.SaveChanges();

            await Task.CompletedTask;
            return rating.Id;

        }
    }
}
