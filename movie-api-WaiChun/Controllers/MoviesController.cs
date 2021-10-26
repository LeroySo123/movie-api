using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using movie_api_WaiChun.Services;
using movie_api_WaiChun.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace movie_api_WaiChun.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoivesStatsService _moivesStatsService;

        public MoviesController(MoivesStatsService moivesStatsService)
        {
            _moivesStatsService = moivesStatsService;
        }


        // GET: <MoviesController>/stats
        [HttpGet]
        [Route("stats")]
        public ActionResult<List<MoviesStats>> Get()
        {
            List<MoviesStats> stats = _moivesStatsService.GetMoivesStats();

            return Ok(stats);
        }


    }
}
