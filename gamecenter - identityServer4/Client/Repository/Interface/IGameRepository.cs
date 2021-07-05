using System.Collections.Generic;
using System.Threading.Tasks;
using gamecenter.Shared.DTOs;
using gamecenter.Shared.Models;

namespace gamecenter.Client.Repository.Interface
{
    public interface IGameRepository
    {
        Task<int> CreateGame(Game game);
        Task DeleteGame(int Id);
        Task<GameDetailDTO> GetGameDetailDTO(int id);
        Task<List<Game>> GetGames();
        Task<PageResponse<List<Game>>> GetGamesByFilter(GameFilterDTO gameFilterDto);
        Task<UpdateGameDTO> GetGamesForUpdate(int id);
        Task<IndexPageDTO> GetIndexPageDto();
        Task UpdateGame(Game game);
    }
}