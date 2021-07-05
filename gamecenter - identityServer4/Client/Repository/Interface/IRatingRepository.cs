using System.Threading.Tasks;
using gamecenter.Shared.Models;

namespace gamecenter.Client.Repository.Interface
{
    public interface IRatingRepository
    {
        Task Vote(GameRating gameRating);
    }
}