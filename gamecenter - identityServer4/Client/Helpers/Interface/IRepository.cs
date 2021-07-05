using System.Collections.Generic;
using gamecenter.Shared.Models;

namespace gamecenter.Client.Helpers.Interface
{
    public interface IRepository
    {
        List<Game> GetGames();
    }
}