using System;
using System.Threading.Tasks;
using gamecenter.Server.Data;
using gamecenter.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gamecenter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RatingController: ControllerBase
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public RatingController(AppDbContext context,
            UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Rate(GameRating gameRating)
        {
            var user = await userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
            var userId = user.Id;

            var currentRating = await context.GameRatings
                .FirstOrDefaultAsync(x => x.GameId == gameRating.GameId &&
                x.UserId == userId);

            if (currentRating == null)
            {
                gameRating.UserId = userId;
                gameRating.RatingDate = DateTime.Today;
                context.Add(gameRating);
                await context.SaveChangesAsync();
            }
            else
            {
                currentRating.Rate = gameRating.Rate;
                await context.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}