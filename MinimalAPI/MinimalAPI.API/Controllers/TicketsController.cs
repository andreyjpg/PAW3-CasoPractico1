using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Core.BusinessLogic;
using Ticket = MinimalAPI.Data.Models.Ticket;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinimalAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController(ITicketBusiness TicketBusiness) : ControllerBase
    {
        // GET: api/<TicketsController>
        [HttpGet]
        public async Task<IEnumerable<Ticket>> Get()
        {
            return await TicketBusiness.GetTickets(id: null);
        }

        // GET api/<TicketsController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Ticket>> Get(int id)
        {
            return await TicketBusiness.GetTickets(id);
        }

        // POST api/<TicketsController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Ticket ticket)
        {
            return await TicketBusiness.UpsertTicketAsync(ticket);
        }

        // PUT api/<TicketsController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Ticket value)
        {
            return await TicketBusiness.UpsertTicketAsync(value);
        }

        // DELETE api/<TicketsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await TicketBusiness.DeleteTicketAsync(id);
        }
    }
}
