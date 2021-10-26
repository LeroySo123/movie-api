using System;
using System.Collections.Generic;
using System.Linq;
using movie_api_WaiChun.Model;

namespace movie_api_WaiChun.Services
{
    public class MoivesStatsService
    {
        private readonly ReadWriteService _readWriteService;
        private const int msTos = 1000;

        public MoivesStatsService(ReadWriteService readWriteService)
        {
            _readWriteService = readWriteService;
        }

        public List<MoviesStats> GetMoivesStats()
        {
            List<MoviesStats> moviesStatsList = new List<MoviesStats>();

            List<Metadata> allMetadatas = _readWriteService.ReadMetadata();
            List<Stats> allStats = _readWriteService.ReadStats();
            List<Metadata> sortMetadate = SortMetadate(allMetadatas);

            foreach (Metadata moive in sortMetadate)
            {
                MoviesStats moviesStats = new MoviesStats();
                var AverageStats = getAverageStats(moive.MovieId, allStats);
                moviesStats.MovieId = moive.MovieId;
                moviesStats.Title = moive.Title;
                moviesStats.AverageWatchDurationS = AverageStats.averageDurationIns;
                moviesStats.Watches = AverageStats.watchesCount;
                moviesStats.ReleaseYear = moive.ReleaseYear;
                moviesStatsList.Add(moviesStats);
            }

            return moviesStatsList.OrderByDescending(x => x.Watches).ThenByDescending( x=> x.ReleaseYear).ToList();
        }



        private static (int watchesCount, int averageDurationIns) getAverageStats(int movieId, List<Stats> allStats)
        {
            var averageDuration =allStats.Where(x=> x.MovieId == movieId).Average(a => a.WatchDurationMs);
            int averageDurationIns = Convert.ToInt32(averageDuration / msTos);
            int watchesCount = allStats.Where(x => x.MovieId == movieId).Count();
            return (watchesCount, averageDurationIns);
        }

        public List<Metadata> SortMetadate (List<Metadata> allMetadatas)
        {
            return allMetadatas.Where(g => g.Language == "EN")
                .GroupBy(g => g.MovieId)
                .Select(g => g.OrderByDescending(x => x.Id).FirstOrDefault()).ToList();
        }
    }
}
