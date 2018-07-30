using Microsoft.EntityFrameworkCore;
using video_games.Models;

namespace video_games.Data
{
    public class VideoGamesContext : DbContext
    {

        public VideoGamesContext(DbContextOptions<VideoGamesContext> options) : base(options)
        {
        }

        public DbSet<ContentRating> ContentRating { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Requirements> Requirements { get; set; }

    }

}
