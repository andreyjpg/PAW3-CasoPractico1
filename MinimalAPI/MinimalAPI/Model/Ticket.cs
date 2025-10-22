using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

    }
}
