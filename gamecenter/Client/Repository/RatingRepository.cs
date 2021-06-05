using System;
using System.Threading.Tasks;
using gamecenter.Client.Helpers.Interface;
using gamecenter.Client.Repository.Interface;
using gamecenter.Shared.Models;

namespace gamecenter.Client.Repository
{
    public class RatingRepository: IRatingRepository
    {
        private readonly IHttpService httpService;

        private readonly string urlBase = "api/rating";

        public RatingRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task Vote(GameRating gameRating)
        {
            var httpResponse = await httpService.Post(urlBase, gameRating);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }
        }
    }
}