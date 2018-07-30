using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using video_games.Data;
using video_games.Models;

namespace video_games.Repositories
{
    public class Repository : IRepository
    {
        private readonly VideoGamesContext gamesContext;

        public Repository(VideoGamesContext gamesContext)
        {
            this.gamesContext = gamesContext;
        }

        public void Add(Games game)
        {
            gamesContext.Games.Add(game);

            gamesContext.SaveChanges();
        }

        public Games FindById(int ID)
        {
            var movie = gamesContext.Games
                .Include(nameof(Games.ContentRating))
                .Include(nameof(Games.Requirements))
                .Where(s => s.GameId == ID)
                .First();

            return movie;
        }

        public IEnumerable<Games> GetGames()
        {
            return gamesContext.Games
                .Include(nameof(Games.ContentRating))
                .Include(nameof(Games.Requirements));
        }

        public IEnumerable<Games> SearchWord(string searchName)
        {
            return gamesContext.Games.Where(s => s.Name.Contains(searchName));
        }

        public void DeleteAll()
        {
            var all = GetGames();
            gamesContext.Games.RemoveRange(all);
            gamesContext.SaveChanges();
        }
    }
}
