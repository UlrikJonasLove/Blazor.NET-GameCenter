using System;
using System.Collections.Generic;
using gamecenter.Client.Helpers.Interface;
using gamecenter.Shared.Models;

namespace gamecenter.Client.Helpers
{
    public class RepositoryInMemory : IRepository
    {
        public List<Game> GetGames()
        {
            return new List<Game>()
            {
                new Game() {Title = "Assassins Creed - Valhalla", 
                ReleaseDate = new DateTime(2020, 11, 30),
                Poster = "https://image.api.playstation.com/vulcan/ap/rnd/202008/1318/8XGEPtD1xoasK0FYkYNcCn1z.png"},
                new Game() {Title = "Little Nightmares", 
                ReleaseDate = new DateTime(2017, 02, 20),
                Poster = "https://store-images.s-microsoft.com/image/apps.61612.65516361464340384.2b1af344-4937-4a1f-af6f-8e009cbf5afa.38b449f3-b1b4-46bc-abd0-d8727a273fff"},
                new Game() {Title = "Little Nightmares 2", 
                ReleaseDate = new DateTime(2021, 02, 25),
                Poster = "https://cdn-prod.scalefast.com/public/assets/user/122595/image/9af5f51bd6495b63b24a92d7be6059ad.png"}
            }; 
        }
    }
}