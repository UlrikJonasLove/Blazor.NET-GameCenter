using System.Collections.Generic;
using gamecenter.Shared.Models;

namespace gamecenter.Client.Helpers
{
    public interface IRepository
    {
        List<Game> GetGames();
    }
}