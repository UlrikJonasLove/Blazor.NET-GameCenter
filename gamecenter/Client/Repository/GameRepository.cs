using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamecenter.Client.Helpers.Interface;
using gamecenter.Client.Repository.Interface;
using gamecenter.Shared.DTOs;
using gamecenter.Shared.Models;

//this file is used for methods to consume the web api's endpoints to the client
namespace gamecenter.Client.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/games";

        public GameRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<IndexPageDTO> GetIndexPageDto()
        {
            var response = await httpService.Get<IndexPageDTO>(url);
            if(!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<UpdateGameDTO> GetGamesForUpdate(int id)
        {
            return await httpService.GetHelper<UpdateGameDTO>($"{url}/update/{id}");
        }

        public async Task<GameDetailDTO> GetGameDetailDTO(int id)
        {
            return await httpService.GetHelper<GameDetailDTO>($"{url}/{id}");
        }

        public async Task<PageResponse<List<Game>>> GetGamesByFilter(GameFilterDTO gameFilterDto)
        {
            var responseHttp = await httpService.Post<GameFilterDTO, List<Game>>($"{url}/filter", gameFilterDto);
            var amountOfPages = int.Parse(responseHttp.HttpResponseMessage.Headers.GetValues("amountOfPages").FirstOrDefault());
            var pageResponse = new PageResponse<List<Game>>()
            {
                Response = responseHttp.Response,
                AmountOfPages = amountOfPages
            };

            return pageResponse;
        }

        public async Task<int> CreateGame(Game game)
        {
            var response = await httpService.Post<Game, int>(url, game);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task UpdateGame(Game game)
        {
            var response = await httpService.Put(url, game);
            if(!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<List<Game>> GetGames()
        {
            var response = await httpService.Get<List<Game>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task DeleteGame(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if(!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}