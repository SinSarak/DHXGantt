using DHXGantt.Data;
using DHXGantt.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHXGantt.Controllers
{
    [Produces("application/json")]
    [Route("api/data")]
    public class DataController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/data
        [HttpGet]
        public object Get()
        {
            return new
            {
                data = _context.Tasks
                   .OrderBy(t => t.SortOrder)
                   .ToList()
                   .Select(t => (WebApiTask)t),
                links = _context.Links
                   .ToList()
                   .Select(l => (WebApiLink)l)
            };
        }

    }
}
