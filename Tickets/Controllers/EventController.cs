using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.Services;

namespace Tickets.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly TicketsDbContext _context;
        public EventController(TicketsDbContext context)
        {
            _context = context;
        }

        // GetAll() is automatically recognized as
        // http://localhost:<port #>/api/Event
        [HttpGet]
        public IEnumerable<Event> GetAll()
        {
            return _context.Event.ToList();
        }
    }
}