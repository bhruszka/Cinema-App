using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Models;

namespace Server.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ScreeningController : ControllerBase {

        private readonly CinemaDbContext _dbContext;

        public ScreeningController (CinemaDbContext dbContext) {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Screening>> GetAll () {
            return _dbContext.Screenings.OrderBy (x => x.Date).ToList ();
        }
    }
}