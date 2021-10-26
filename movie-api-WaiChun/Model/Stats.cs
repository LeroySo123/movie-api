using CsvHelper.Configuration.Attributes;

namespace movie_api_WaiChun.Model
{
    public class Stats
    {
        [Name("movieId")]
        public int MovieId { get; set; }
        [Name("watchDurationMs")]
        public int WatchDurationMs { get; set; }
    }
}
