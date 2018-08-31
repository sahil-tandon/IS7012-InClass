using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase {

        private readonly MovieContext _context;
        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Movie>> Get() {
            return _context.Movie.ToList();
        }

    }
}