using Core.DTOs;

namespace MVC.Models
{
    public class HomeViewModel
    {
        public string Title { get; set; } = "Tickets";
        public IEnumerable<TicketDTO> Tickets { get; set; } = [];
    }
}
